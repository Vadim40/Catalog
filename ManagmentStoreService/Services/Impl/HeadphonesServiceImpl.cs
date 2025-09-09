using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Headphones;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models.Enums;
using ManagmentStoreService.Models.HeadphonesEntities;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
using ManagmentStoreService.Models.HeadphonesEntities;


namespace ManagmentStoreService.Services.Impl
{
    public class HeadphonesServiceImpl : IHeadphoneService
    {
        private readonly ManagStoreDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        private readonly ILogger<PhoneServiceImpl> _logger;

        public HeadphonesServiceImpl(
            ManagStoreDbContext context,
            ICloudinaryService cloudinaryService,
            IMapper mapper,
            ILogger<PhoneServiceImpl> logger,
            IItemService itemService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
            _logger = logger;
            _itemService = itemService;
        }
        public async Task AddImagesToHeadphonesModelAsync(UploadVariantImagesDto createImagesDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                for (int i = 0; i < createImagesDto.Images.Count; i++)
                {


                    var result = await _cloudinaryService.UploadImageAsync(createImagesDto.Images[i]);
                    var headphonesImage = new HeadphonesImage
                    {
                        IsMain = (i == 0),
                        Url = result.Url,
                        PublicId = result.PublicId
                    };
                    _context.HeadphonesImages.Add(headphonesImage);
                    await _context.SaveChangesAsync();

                    var variantImage = new HeadphonesVariantImage
                    {
                        VariantId = createImagesDto.VariantId,
                        ImageId = headphonesImage.Id
                    };

                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save phone");
                await transaction.RollbackAsync();
                throw new Exception("Failed to save phone.", ex);
            }

        }

        public async Task AddNewHeadphonesAsync(CreateHeadphonesDto headphonesDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var itemId = await _itemService.SaveItemAsync(headphonesDto.SerialNumber, CategoryType.HeadPhones);

                var phone = new Headphones
                {

                    VariantId = headphonesDto.VariantId,
                    ItemId = itemId
                };
                _context.Headphones.Add(phone);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save phone");
                await transaction.RollbackAsync();
                throw new Exception("Failed to save phone.", ex);
            }

        }
        public async Task AddNewHeadphonesModelAsync(CreateHeadponesModelDto headphonesModelDto)
        {
            var phoneModel = new HeadphonesModel
            {
                ManufacturerId = headphonesModelDto.ManufacturerId,
                Name = headphonesModelDto.Name
            };
            _context.HeadphonesModels.Add(phoneModel);
            await _context.SaveChangesAsync();
        }


        public async Task AddNewHeadphonesSpecAsync(CreateHeadphonesSpecDto headphonesSpesDto)
        {
            var phoneSpec = new HeadphonesSpec
            {
                IsWireless = headphonesSpesDto.IsWireless,
                FrequencyRangeHz = headphonesSpesDto.FrequencyRangeHz,
                CodecId = headphonesSpesDto.CodecId
            };
            _context.HeadphonesSpecs.Add(phoneSpec);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HeadphonesModelDto>> GetHeadphonesModelsByNameAsync(string name)
        {
            var headphonesModels = await _context.HeadphonesModels
                                              .Where(h => Fuzz.Ratio(name, h.Name) > 0.7)
                                             .ToListAsync();
            return _mapper.Map<List<HeadphonesModelDto>>(headphonesModels);
        }

        public async Task<IEnumerable<HeadphonesSpecDto>> GetHeadphonesSpecsByModelIdAsync(int modelId)
        {
            var headphonesSpecs = await _context.HeadphonesSpecs
                .Join(_context.HeadphonesVariants,
                    s => s.Id,
                    p => p.SpecId,
                    (s, p) => new { Spec = s, Variant = p })
                .Where(x => x.Variant.ModelId == modelId)
                .Select(x => new HeadphonesSpec
                {
                    Id = x.Spec.Id,
                    IsWireless = x.Spec.IsWireless,
                    FrequencyRangeHz = x.Spec.FrequencyRangeHz,
                    CodecId = x.Spec.CodecId
                })
                .ToListAsync();
            return _mapper.Map<List<HeadphonesSpecDto>>(headphonesSpecs);
        }


    }
}
