using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Headphones;
using ManagmentStoreService.Dto.Phone;
using Microsoft.EntityFrameworkCore;
using StoreService.Config;
using StoreService.Models;
using StoreService.Models.HeadphonesEntities;
using StoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Services.Impl
{
    public class HeadphonesServiceImpl : IHeadphoneService
    {
        private readonly ManagStoreDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;

        public HeadphonesServiceImpl(ManagStoreDbContext context, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task AddImagesToHeadphonesModelAsync(CreateImagesDto createImagesDto)
        {
            for (int i = 0; i < createImagesDto.Images.Count; i++)
            {

                var result = await _cloudinaryService.UploadImageAsync(createImagesDto.Images[i]);
                var headphonesImage = new HeadphonesImage
                {
                    ModelId = createImagesDto.VariantId,
                    IsMain = (i == 0),
                    Url = result.Url,
                    PublicId = result.PublicId
                };
                _context.HeadphonesImages.Add(headphonesImage);
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddNewHeadphonesAsync(CreateHeadphonesDto headphonesDto)
        {
            var itemId = await SaveItem(headphonesDto);
            var priceId = await GetPriceId(headphonesDto.ModelId, headphonesDto.SpecId);

            var phone = new Headphones
            {
                ModelId = headphonesDto.ModelId,
                SpecId = headphonesDto.SpecId,
                VariantId = priceId,
                ItemId = itemId
            };
            _context.Headphones.Add(phone);
            await _context.SaveChangesAsync();

        }
        private async Task<int> SaveItem(CreateHeadphonesDto createHeadphonesDto)
        {
            var item = new Item
            {
                SerialNumber = createHeadphonesDto.SerialNumber,
                CategoryId = 2, //TODO: replace with enum
                StatusId = 1,
                LocationId = 1
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        private async Task<int> GetPriceId(int modelId, int specId)
        {
            var priceId = await _context.HeadphonesVariants
                .Where(h => h.ModelId == modelId && h.SpecId == specId)
               .Select(h => h.Id)
               .FirstOrDefaultAsync();
            if (priceId == 0)
            {
                throw new KeyNotFoundException($"Variant for {modelId} modelId and {specId} specId not found");
            }
            return priceId;
        }




        public async Task AddNewHeadphonesModelAsync(CreateHeadponesModelDto headphonesModelDto)
        {
            var phoneModel = new HeadphonesModel
            {
                ManufacturerId = headphonesModelDto.ManufacturerId,
                Name = headphonesModelDto.Name,
                Color = headphonesModelDto.Color
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
                                              .Where(h => h.ModelId == modelId)
                                              .ToListAsync();
            return _mapper.Map<List<HeadphonesSpecDto>>(headphonesSpecs);
        }


    }
}
