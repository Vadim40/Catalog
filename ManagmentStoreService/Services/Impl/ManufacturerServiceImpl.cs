using AutoMapper;
using ManagmentStoreService.Config;
using ManagmentStoreService.Dto;
using Microsoft.EntityFrameworkCore;

namespace ManagmentStoreService.Services.Impl
{
    public class ManufacturerServiceImpl : IManufacturerService
    {
        private readonly ManagStoreDbContext _context;
        private readonly IMapper _mapper;
        public ManufacturerServiceImpl(ManagStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdNameDto>> GetAllAsync()
        {
            var manufacturers = await _context.Manufacturers.ToListAsync();
            return _mapper.Map<List<IdNameDto>>(manufacturers);
        }
    }
}
