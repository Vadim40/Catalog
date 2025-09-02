using ManagmentStoreService.Dto;

namespace ManagmentStoreService.Services
{
    public interface IColorService
    {
        public Task<IEnumerable<ColorDto>> GetColorAsync(string search);
        public Task<IEnumerable<ColorDto>> GetColorAsync(int modelId);
    }
}
