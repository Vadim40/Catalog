using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models.Enums;
using ManagmentStoreService.Models.PhoneEntities;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
using ManagmentStoreService.Models;
using ManagmentStoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Services.Impl
{
    public class PhoneServiceImpl : IPhoneService
    {
        private readonly ManagStoreDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        private readonly ILogger<PhoneServiceImpl> _logger;
        public PhoneServiceImpl(
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
        public async Task AddImagesToPhoneModelAsync(CreateImagesDto createImagesDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                for (int i = 0; i < createImagesDto.Images.Count; i++)
                {

                    var result = await _cloudinaryService.UploadImageAsync(createImagesDto.Images[i]);
                    var phoneImage = new PhoneImage
                    {
                        IsMain = (i == 0),
                        Url = result.Url,
                        PublicId = result.PublicId
                    };
                    _context.PhoneImages.Add(phoneImage);
                    await _context.SaveChangesAsync();

                    var variantImage = new PhoneVariantImage
                    {
                        VariantId = createImagesDto.VariantId,
                        ImageId = phoneImage.Id
                    };

                    _context.PhoneVariantImages.Add(variantImage);

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

        public async Task AddNewPhoneAsync(CreatePhoneDto phoneDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var itemId = await _itemService.SaveItemAsync(phoneDto.SerialNumber, CategoryType.Phones);
               

                var phone = new Phone
                {
                    VariantId = phoneDto.VariantId,
                    ItemId = itemId
                };
                _context.Phones.Add(phone);
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



        public async Task AddNewPhoneModelAsync(CreatePhoneModelDto phoneModelDto)
        {
            var phoneModel = new PhoneModel
            {
                ManufacturerId = phoneModelDto.ManufacturerId,
                Name = phoneModelDto.Name
            };
            _context.PhoneModels.Add(phoneModel);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewPhoneSpecAsync(CreatePhoneSpecDto phoneSpesDto)
        {
            var phoneSpec = new PhoneSpec
            {
                StorageGb = phoneSpesDto.StorageGb,
                RamGb = phoneSpesDto.RamGb,
                DisplayIn = phoneSpesDto.DisplayIn,
                CameraMp = phoneSpesDto.CameraMp
            };
            _context.PhoneSpecs.Add(phoneSpec);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhoneModelDto>> GetPhoneModelsByNameAsync(string name)
        {
            var phoneModels = await _context.PhoneModels
                .Where(p => Fuzz.Ratio(name, p.Name) > 0.7)
                .ToListAsync();

            return _mapper.Map<List<PhoneModelDto>>(phoneModels);
        }

        public async Task<IEnumerable<PhoneSpecDto>> GetPhoneSpecsByModelIdAsync(int modelId)
        {
            var phoneSpecs = await _context.PhoneSpecs
                .Join(_context.PhoneVariants,
                    s => s.Id,
                    p => p.SpecId,
                    (s, p) => new { Spec = s, Variant = p })
                .Where(x => x.Variant.ModelId == modelId)
                .Select(x => new PhoneSpec
                {
                    Id = x.Spec.Id,
                    RamGb = x.Spec.RamGb,
                    DisplayIn = x.Spec.DisplayIn,
                    CameraMp = x.Spec.CameraMp
                })
                .ToListAsync();

            return _mapper.Map<List<PhoneSpecDto>>(phoneSpecs);
        }
    }
}
