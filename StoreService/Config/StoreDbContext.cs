

using StoreService.Models;
using Microsoft.EntityFrameworkCore;
using StoreService.Models.HeadphonesEntities;
using StoreService.Models.PhoneEntities;


namespace StoreService.Config
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) 
        { 
        }
        public DbSet<Category> Categories  => Set<Category>();
        public DbSet<HeadphonesImage> HeadphonesImages  => Set<HeadphonesImage>();
        public DbSet<Headphones> Headphones => Set<Headphones>();
        public DbSet<HeadphonesModel> HeadphonesModels => Set<HeadphonesModel>();
        public DbSet<HeadphonesSpec> HeadphonesSpecs => Set<HeadphonesSpec>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemStatus> ItemsStatuses => Set<ItemStatus>();
        public DbSet<Location > Locations => Set<Location>();
        public DbSet<Manufacturer> Manufacturer => Set<Manufacturer>();
        public DbSet<PhoneImage> PhoneImages => Set<PhoneImage>();
        public DbSet<Phone> Phones => Set<Phone>();
        public DbSet<PhoneModel> PhoneModels => Set<PhoneModel>();
        public DbSet<PhoneSpec> PhoneSpecs => Set<PhoneSpec>();
        public DbSet<PhonePrice> PhonePrices => Set<PhonePrice>();
        public DbSet<HeadphonesPrice> HeadphonesPrices => Set<HeadphonesPrice>();

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.SerialNumber)
                .IsUnique();
        }
    }

}
