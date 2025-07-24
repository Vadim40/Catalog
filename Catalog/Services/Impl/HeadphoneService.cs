using Catalog.Config;
using Catalog.Dto;
using Catalog.Models;
using Catalog.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Catalog.Services.Impl
{
    public class HeadphoneService : IHeadphonesService
    {
        private readonly CatalogDbContext _dbContext;
        public HeadphoneService(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<Headphones> GetHeadphonesByIdAsync(int headphonesId)
        {
            var headphones = await _dbContext.Headphones
            .Include(h => h.Model)
            .Include(h => h.HeadphonesSpec)
            .Include(h => h.HeadphonesPrice)
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
                .Include(h => h.HeadphonesSpec)
                .Include(h => h.HeadphonesPrice)
                .Where(h =>
                   (filter.Manufacturers == null || filter.Manufacturers.Count == 0 ||
                    filter.Manufacturers.Contains(h.Model.ManufacturerId))
                    &&
                     (filter.Codecs == null || filter.Codecs.Count == 0 ||
                    filter.Codecs.Contains(h.HeadphonesSpec.CodecId))
                    &&
                    (!filter.IsWireless.HasValue ||h.HeadphonesSpec.IsWireless == filter.IsWireless)
                    &&
                     (!filter.MinCost.HasValue || h.HeadphonesPrice.Cost >= filter.MinCost.Value)
                    &&
                    (!filter.MaxCost.HasValue || h.HeadphonesPrice.Cost <= filter.MaxCost.Value)
                     )
                    .ToListAsync();
        }

        public Task<IEnumerable<Headphones>> GetSimilarHeadphonesAsync(int headphonesId)
        {
            throw new NotImplementedException();
        }
    }
}
