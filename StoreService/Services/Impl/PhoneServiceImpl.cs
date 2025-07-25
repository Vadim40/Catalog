using StoreService.Config;
using StoreService.Dto;
using StoreService.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreService.Models.Phonesad;

namespace StoreService.Services.Impl
{
    public class PhoneServiceImpl : IPhoneService
    {
        private readonly StoreDbContext _dbContext;

        public PhoneServiceImpl(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Phone> GetPhoneById(int phoneId)
        {
            var phone = await _dbContext.Phones
            .Include(p => p.Model)
            .Include(p => p.PhoneSpec)
            .Include(p => p.PhonePrice)
            .FirstOrDefaultAsync(p => p.Id == phoneId);

            if (phone is null)
            {
                throw new KeyNotFoundException($"Phone with {phoneId} id not found");
            }
            return phone;
        }

        public async Task<IEnumerable<Phone>> GetPhonesByFilterAsync(PhoneFilter filter)
        {
            return await _dbContext.Phones
           .Include(p => p.Model)
           .Include(p => p.PhoneSpec)
           .Include(p => p.PhonePrice)
           .Where(p =>
               (filter.Manufacturers == null || filter.Manufacturers.Count == 0 ||
                   filter.Manufacturers.Contains(p.Model.ManufacturerId))
               &&
               (string.IsNullOrEmpty(filter.Color) || p.Model.Color == filter.Color)
               &&
               (!filter.MinStorageGb.HasValue || p.PhoneSpec.StorageGb >= filter.MinStorageGb.Value)
               &&
               (!filter.MaxStorageGb.HasValue || p.PhoneSpec.StorageGb <= filter.MaxStorageGb.Value)
               &&
               (!filter.MinRamGb.HasValue || p.PhoneSpec.RamGb >= filter.MinRamGb.Value)
               &&
               (!filter.MaxRamGb.HasValue || p.PhoneSpec.RamGb <= filter.MaxRamGb.Value)
               &&
               (!filter.MinDisplayIn.HasValue || p.PhoneSpec.DisplayIn >= filter.MinDisplayIn.Value)
               &&
               (!filter.MaxDisplayIn.HasValue || p.PhoneSpec.DisplayIn <= filter.MaxDisplayIn.Value)
               &&
               (!filter.MinCameraMp.HasValue || p.PhoneSpec.CameraMp >= filter.MinCameraMp.Value)
               &&
               (!filter.MaxCameraMp.HasValue || p.PhoneSpec.CameraMp <= filter.MaxCameraMp.Value)
               &&
               (!filter.MinCost.HasValue || p.PhonePrice.Cost >= filter.MinCost.Value)
               &&
               (!filter.MaxCost.HasValue || p.PhonePrice.Cost <= filter.MaxCost.Value)
           )
           .ToListAsync();

        }

        public async Task<IEnumerable<Phone>> GetSimilarPhonesAsync(int phoneId)
        {
            var phone = await GetPhoneById(phoneId);
           
            return await _dbContext.Phones
            .Include(p => p.Model)
            .Include(p => p.PhoneSpec)
            .Include(p => p.PhonePrice)
            .Where(p =>
             p.Model.ManufacturerId == phone.Model.ManufacturerId
             &&
               phone.PhonePrice.Cost * 1.15m <= p.PhonePrice.Cost &&  p.PhonePrice.Cost *0.85m >= p.PhonePrice.Cost
             )
             .ToListAsync();
        }
    }
}
