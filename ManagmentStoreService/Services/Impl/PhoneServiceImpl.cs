using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models.Enums;
using ManagmentStoreService.Models.PhoneEntities;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
using EntityFramework.Exceptions.Common;


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
        public async Task AddImagesToModelAsync(VariantImagesUploadDto createImagesDto)
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

        public async Task AddPhoneAsync(PhoneCreateDto phoneDto)
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



        public async Task AddModelAsync(PhoneModelCreateDto phoneModelDto)
        {
            var phoneModel = new PhoneModel
            {
                ManufacturerId = phoneModelDto.ManufacturerId,
                Name = phoneModelDto.Name
            };
            _context.PhoneModels.Add(phoneModel);
            await _context.SaveChangesAsync();
        }

        public async Task AddSpecAsync(PhoneSpecCreateDto phoneSpecDto)
        {
            var phoneSpec = _mapper.Map<PhoneSpec>(phoneSpecDto);

            try
            {
                _context.PhoneSpecs.Add(phoneSpec);
                await _context.SaveChangesAsync();
            }
            catch (UniqueConstraintException ex)
            {
                if (true /*ex.ConstraintName == "IX_UniquePhoneSpec"*/) //todo: replace
                {
                    throw new InvalidOperationException("This spec already exist", ex);
                }
            }
        }

        public async Task<IEnumerable<PhoneModelDto>> SearchModelsAsync(string name)
        {

            var phoneModels = await _context.PhoneModels
                             .Include(p => p.Manufacturer)
                             .ToListAsync();


            var filteredModels = phoneModels
                                .Where(x => Fuzz.PartialRatio(name.ToLower(), (x.Manufacturer.Name + x.Name).ToLower()) > 60)
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
                            .Where(p =>
                                (searchNumbers.Length >= 1 ? p.RamGb.ToString().StartsWith(searchNumbers[0].ToString()) : true)
                                &&
                                (searchNumbers.Length == 2 ? p.StorageGb.ToString().StartsWith(searchNumbers[1].ToString()) : true)
                            )
                            .ToListAsync();
            return _mapper.Map<List<PhoneSpecDto>>(phoneSpecs);
        }

        public async Task<IEnumerable<ImageDto>> GetImagesAsync(int modelId, int colorId)
        {
            var images = await (from i in _context.PhoneImages
                                join vi in _context.PhoneVariantImages on i.Id equals vi.ImageId
                                join pv in _context.PhoneVariants on vi.VariantId equals pv.Id
                                where pv.ModelId == modelId && pv.ColorId == colorId
                                select i)
                    .ToListAsync();
            return _mapper.Map<List<ImageDto>>(images);
        }

        public async Task<int> AddPhoneVariantAsync(PhoneVariantCreateDto variantDto)
        {
            try
            {
                var variant = _mapper.Map<PhoneVariant>(variantDto);
                _context.PhoneVariants.Add(variant);
                await _context.SaveChangesAsync();
                return variant.Id;
            }
            catch (UniqueConstraintException ex)
            {
                if (true /*ex.ConstraintName == "IX_UniquePhoneSpec"*/) //todo: replace
                {
                    throw new InvalidOperationException("This variant already exist", ex);
                }
            }
        }

        public async Task<IEnumerable<PhoneVariantDto>> SearchVariantsAsync(string name)
        {
            // todo: replace this temporary solution

            var variants = await _context.PhoneVariants
                            .Join(_context.PhoneModels,
                                  ph => ph.ModelId,
                                  pm => pm.Id,
                                  (ph, pm) => new { ph, pm })
                            .Join(_context.Manufacturers,
                                x => x.pm.ManufacturerId,
                                m => m.Id,
                                (x, m) => new { x.ph, x.pm, m })
                            .Join(_context.Colors,
                                x => x.ph.ColorId,
                                c => c.Id,
                                (x, c) => new PhoneVariantDto
                                {
                                    Id = x.ph.Id,
                                    ModelId = x.pm.Id,
                                    ColorId = c.Id,
                                    Cost = x.ph.Cost,
                                    Name = x.m.Name + " " + x.pm.Name + " " + c.Name,

                                })
                            .ToListAsync();

            var filteredVariants = variants.Where(v => Fuzz.PartialRatio(name.ToLower(), v.Name) > 70);
            foreach (var item in filteredVariants)
            {
                item.Specs = (await GetSpecsAsync(item.ModelId)).ToList();
                item.Images = (await GetImagesAsync(item.ModelId, item.ColorId)).ToList();

            }

            return filteredVariants;
        }
    }
}
