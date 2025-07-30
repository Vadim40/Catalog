using ManagmentStoreService.Dto;
using ManagmentStoreService.Models.Enums;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
using ManagmentStoreService.Models;

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
                StatusId = (int) StatusType.InStorage, // TODO: define statuses and locations
                LocationId  = (int) LocationType.Storage
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
    }
}
