using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using Microsoft.EntityFrameworkCore;
using StoreService.Config;
using StoreService.Models;
using StoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Services.Impl
{
    public class PhoneService : IPhoneService
    {
        private readonly ManagStoreDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;
        public PhoneService( ManagStoreDbContext context, ICloudinaryService cloudinaryService, IMapper mapper )
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
        }
        public async Task AddImagesToPhoneModelAsync(CreateImagesDto createImagesDto)
        {
            for (int i =0; i<createImagesDto.Images.Count; i++)
            {
               
                var result = await _cloudinaryService.UploadImageAsync(createImagesDto.Images[i]);
                var phoneImage = new PhoneImage
                {
                    ModelId = createImagesDto.ModelId,
                    IsMain = (i == 0),
                    Url = result.Url,
                    PublicId = result.PublicId
                };
                _context.PhoneImages.Add(phoneImage);
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddNewPhoneAsync(CreatePhoneDto phoneDto)
        {
           
            var itemId = await SaveItem(phoneDto); 
            var priceId = await GetPriceId(phoneDto.ModelId, phoneDto.SpecId); 

            var phone = new Phone
            {
                ModelId = phoneDto.ModelId,
                SpecId = phoneDto.SpecId,
                PriceId = priceId,
                ItemId = itemId
            };
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
           
        }
        private async Task<int> SaveItem(CreatePhoneDto phoneDto)
        {
            var item = new Item
            {
                SerialNumber = phoneDto.SerialNumber,
                CategoryId = 1, //TODO: replace with enum
                StatusId = 1,
                LocationId = 1
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        private async Task<int> GetPriceId(int modelId, int specId)
        {
             var priceId = await _context.PhonePrices
                 .Where(p => p.ModelId == modelId && p.SpecId == specId)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
            if (priceId == 0)
            {
                throw new KeyNotFoundException($"Price for {modelId} modelId and {specId} specId not found");
            }
            return priceId;
        }


        public async Task AddNewPhoneModelAsync(CreatePhoneModelDto phoneModelDto)
        {
            var phoneModel = new PhoneModel
            {
                ManufacturerId = phoneModelDto.ManufacturerId,
                Name = phoneModelDto.Name,
                Color = phoneModelDto.Color
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

        public async Task<IEnumerable<PhoneSpecDto>> GetPhoneSpecByModelIdAsync(int modelId)
        {
           var phoneSpecs = await _context.PhoneSpecs
                                            .Where(p => p.ModelId == modelId)
                                            .ToListAsync();
            return _mapper.Map<List<PhoneSpecDto>>(phoneSpecs);
        }
    }
}
