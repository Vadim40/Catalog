using ManagmentStoreService.Config;
using ManagmentStoreService.Dto;

namespace ManagmentStoreService.Services.Impl
{
    public class ManufacturerServiceImpl : IManufacturerService
    {
        private readonly ManagStoreDbContext _context;
        public ManufacturerServiceImpl(ManagStoreDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<IdNameDto>> getManufacturers()
        {
            throw new NotImplementedException();
        }
    }
}
