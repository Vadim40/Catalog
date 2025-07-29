using ManagmentStoreService.Dto;
using ManagmentStoreService.Models.Enums;
using Microsoft.EntityFrameworkCore;
using StoreService.Config;
using StoreService.Models;

namespace ManagmentStoreService.Services.Impl
{
    public class ItemServiceImpl : IItemService
    {
        private readonly ManagStoreDbContext _context;
        public ItemServiceImpl(ManagStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveItemAsync(string serialNumber, CategoryType category)
        {
            var item = new Item
            {
                SerialNumber = serialNumber,
                CategoryId = (int) category,
                StatusId = 1, // TODO: define statuses and locations
                LocationId = 1
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
    }
}
