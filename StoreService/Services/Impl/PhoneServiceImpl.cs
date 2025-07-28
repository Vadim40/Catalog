using StoreService.Config;
using StoreService.Dto;
using StoreService.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreService.Models.PhoneEntities;


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
            .Include(p => p.Spec)
            .Include(p => p.Price)
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
           .Include(p => p.Spec)
           .Include(p => p.Price)
           .Where(p =>
               (filter.Manufacturers == null || filter.Manufacturers.Count == 0 ||
                   filter.Manufacturers.Contains(p.Model.ManufacturerId))
               &&
               (string.IsNullOrEmpty(filter.Color) || p.Model.Color == filter.Color)
               &&
               (!filter.MinStorageGb.HasValue || p.Spec.StorageGb >= filter.MinStorageGb.Value)
               &&
               (!filter.MaxStorageGb.HasValue || p.Spec.StorageGb <= filter.MaxStorageGb.Value)
               &&
               (!filter.MinRamGb.HasValue || p.Spec.RamGb >= filter.MinRamGb.Value)
               &&
               (!filter.MaxRamGb.HasValue || p.Spec.RamGb <= filter.MaxRamGb.Value)
               &&
               (!filter.MinDisplayIn.HasValue || p.Spec.DisplayIn >= filter.MinDisplayIn.Value)
               &&
               (!filter.MaxDisplayIn.HasValue || p.Spec.DisplayIn <= filter.MaxDisplayIn.Value)
               &&
               (!filter.MinCameraMp.HasValue || p.Spec.CameraMp >= filter.MinCameraMp.Value)
               &&
               (!filter.MaxCameraMp.HasValue || p.Spec.CameraMp <= filter.MaxCameraMp.Value)
               &&
               (!filter.MinCost.HasValue || p.Price.Cost >= filter.MinCost.Value)
               &&
               (!filter.MaxCost.HasValue || p.Price.Cost <= filter.MaxCost.Value)
           )
           .ToListAsync();

        }

        public async Task<IEnumerable<Phone>> GetSimilarPhonesAsync(int phoneId)
        {
            var phone = await GetPhoneById(phoneId);
           
            return await _dbContext.Phones
            .Include(p => p.Model)
            .Include(p => p.Spec)
            .Include(p => p.Price)
            .Where(p =>
             p.Model.ManufacturerId == phone.Model.ManufacturerId
             &&
               phone.Price.Cost * 1.15m <= p.Price.Cost &&  p.Price.Cost *0.85m >= p.Price.Cost
             )
             .ToListAsync();
        }
    }
}
