using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models.Enums;
using ManagmentStoreService.Models.PhoneEntities;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;


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
        public async Task AddImagesToModelAsync(CreateImagesDto createImagesDto)
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

        public async Task AddPhoneAsync(CreatePhoneDto phoneDto)
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



        public async Task AddModelAsync(CreatePhoneModelDto phoneModelDto)
        {
            var phoneModel = new PhoneModel
            {
                ManufacturerId = phoneModelDto.ManufacturerId,
                Name = phoneModelDto.Name
            };
            _context.PhoneModels.Add(phoneModel);
            await _context.SaveChangesAsync();
        }

        public async Task AddSpecAsync(CreatePhoneSpecDto phoneSpesDto)
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

        public async Task<IEnumerable<PhoneModelDto>> SearchModelsAsync(string name)
        {
           
            var phoneModels = await _context.PhoneModels
                             .Include(p => p.Manufacturer)
                             .ToListAsync();


            var filteredModels = phoneModels
                                .Where(x => Fuzz.PartialRatio(name, (x.Manufacturer.Name + x.Name).ToLower()) > 60)
                                .ToList();


            return _mapper.Map<List<PhoneModelDto>>(filteredModels);

        }

        public async Task<IEnumerable<PhoneSpecDto>> GetSpecsAsync(int modelId)
        {
            var phoneSpecs = await _context.PhoneSpecs
                             .Where(s => _context.PhoneVariants
                             .Any(v => v.SpecId == s.Id && v.ModelId == modelId))
                             .ToListAsync();


            return _mapper.Map<List<PhoneSpecDto>>(phoneSpecs);
        }

        public async Task<IEnumerable<PhoneSpecDto>> SearchSpecsAsync(string search)
        {

            var searchNumbers = search.Split('/')
                                 .Select(s => int.Parse(s.Trim()))
                                 .ToArray();

            var phoneSpecs = await _context.PhoneSpecs
                            .Where(p => p.RamGb == searchNumbers[0]
                            && (searchNumbers.Length == 1 || p.StorageGb == searchNumbers[1]))
                            .ToListAsync();
            return _mapper.Map<List<PhoneSpecDto>>(phoneSpecs);
        }
    }
}
