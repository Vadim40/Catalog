

using ManagmentStoreService.Models;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Models.HeadphonesEntities;
using ManagmentStoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Config
{
    public class ManagStoreDbContext : DbContext
    {
        public ManagStoreDbContext(DbContextOptions<ManagStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<HeadphonesImage> HeadphonesImages => Set<HeadphonesImage>();
        public DbSet<Headphones> Headphones => Set<Headphones>();
        public DbSet<HeadphonesModel> HeadphonesModels => Set<HeadphonesModel>();
        public DbSet<HeadphonesSpec> HeadphonesSpecs => Set<HeadphonesSpec>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemStatus> ItemsStatuses => Set<ItemStatus>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<PhoneImage> PhoneImages => Set<PhoneImage>();
        public DbSet<Phone> Phones => Set<Phone>();
        public DbSet<PhoneModel> PhoneModels => Set<PhoneModel>();
        public DbSet<PhoneSpec> PhoneSpecs => Set<PhoneSpec>();
        public DbSet<PhoneVariant> PhoneVariants => Set<PhoneVariant>();
        public DbSet<HeadphonesVariant> HeadphonesVariants => Set<HeadphonesVariant>();

        public DbSet<PhoneVariantImage> PhoneVariantImages => Set<PhoneVariantImage>();
        public DbSet<HeadphonesVariantImage> HeadphonesVariantImages => Set<HeadphonesVariantImage>();

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeadphonesVariantImage>()
            .HasKey(hvi => new { hvi.VariantId, hvi.ImageId });

            modelBuilder.Entity<PhoneVariantImage>()
            .HasKey(pvi => new { pvi.VariantId, pvi.ImageId });
        }
    }
}
