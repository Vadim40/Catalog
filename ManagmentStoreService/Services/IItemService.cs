using ManagmentStoreService.Dto;
using ManagmentStoreService.Models.Enums;

namespace ManagmentStoreService.Services
{
    public interface IItemService
    {
      //  public Task<ItemDto> GetItemDtoBySerialNumberAsync( int serialNumber);
      // public Task<IEnumerable<CategoryDto>> GetCategoriesAsync ();
        public Task<int> SaveItemAsync(string serialNumber, CategoryType category);
    }
}
