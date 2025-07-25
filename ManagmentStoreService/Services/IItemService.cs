namespace ManagmentStoreService.Services
{
    public interface IItemService
    {
        public Task<ItemDto> GetItemDtoByIdAsync( int id);

    }
}
