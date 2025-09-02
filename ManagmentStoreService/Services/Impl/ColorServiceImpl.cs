using AutoMapper;
using FuzzySharp;
using ManagmentStoreService.Config;
using ManagmentStoreService.Dto;
using Microsoft.EntityFrameworkCore;

namespace ManagmentStoreService.Services.Impl
{
    public class ColorServiceImpl : IColorService
    {
        private readonly ManagStoreDbContext _context;
        private readonly IMapper _mapper;
        public ColorServiceImpl(ManagStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ColorDto>> GetColorAsync(string search)
        {
            var colors = await _context.Colors.ToListAsync();

            var filteredColors = colors.Where(c => Fuzz.PartialRatio(search, c.Name.ToLower()) > 70);

            return _mapper.Map<List<ColorDto>>(filteredColors);
        }

        public async Task<IEnumerable<ColorDto>> GetColorAsync(int modelId)
        {
            var filteredColors = await _context.Colors
                .Where(c => _context.PhoneVariants
                    .Any(v => v.ColorId == c.Id && v.ModelId == modelId))
                .ToListAsync();

            return _mapper.Map<List<ColorDto>>(filteredColors);
        }
    }
}
