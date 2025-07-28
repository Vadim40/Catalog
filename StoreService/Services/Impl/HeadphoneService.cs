using StoreService.Config;
using StoreService.Dto;
using StoreService.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreService.Models.HeadphonesEntities;


namespace StoreService.Services.Impl
{
    public class HeadphoneService : IHeadphonesService
    {
        private readonly StoreDbContext _dbContext;
        public HeadphoneService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<Headphones> GetHeadphonesByIdAsync(int headphonesId)
        {
            var headphones = await _dbContext.Headphones
            .Include(h => h.Model)
            .Include(h => h.Spec)
            .Include(h => h.Price)
            .FirstOrDefaultAsync(h => h.Id == headphonesId);

            if (headphones is null)
            {
                throw new KeyNotFoundException($"Headphones with {headphonesId} id not found");
            }
            return headphones;
        }
        public async Task<IEnumerable<Headphones>> GetHeadphonesByFilterAsync(HeadphonesFilter filter)
        {
            return await _dbContext.Headphones
                .Include(h => h.Model)
                .Include(h => h.Spec)
                .Include(h => h.Price)
                .Where(h =>
                   (filter.Manufacturers == null || filter.Manufacturers.Count == 0 ||
                    filter.Manufacturers.Contains(h.Model.ManufacturerId))
                    &&
                     (filter.Codecs == null || filter.Codecs.Count == 0 ||
                    filter.Codecs.Contains(h.Spec.CodecId))
                    &&
                    (!filter.IsWireless.HasValue ||h.Spec.IsWireless == filter.IsWireless)
                    &&
                     (!filter.MinCost.HasValue || h.Price.Cost >= filter.MinCost.Value)
                    &&
                    (!filter.MaxCost.HasValue || h.Price.Cost <= filter.MaxCost.Value)
                     )
                    .ToListAsync();
        }

        public async Task<IEnumerable<Headphones>> GetSimilarHeadphonesAsync(int headphonesId)
        {
            var headphones = await GetHeadphonesByIdAsync(headphonesId);

            return await _dbContext.Headphones
               .Include(h => h.Model)
               .Include(h => h.Spec)
               .Include(h => h.Price)
               .Where(h =>
               h.Id != headphonesId
                &&
               headphones.Model.ManufacturerId == h.Model.ManufacturerId
               && 
               h.Price.Cost <= headphones.Price.Cost*1.15m
               &&
                 h.Price.Cost >= headphones.Price.Cost * 0.85m
               &&
               headphones.Spec.IsWireless == h.Spec.IsWireless
               )
               .ToListAsync();
        }
    }
}
