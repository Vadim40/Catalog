

using Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Config
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) 
        { 
        }
        public DbSet<Category> Categories  => Set<Category>();
    }
}
