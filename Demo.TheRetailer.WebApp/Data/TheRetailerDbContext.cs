using Microsoft.EntityFrameworkCore;
using Demo.TheRetailer.WebApp.Models;

namespace Demo.TheRetailer.WebApp.Data
{
    public class TheRetailerDbContext : DbContext
    {
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public string DbPath { get; }

        public TheRetailerDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "the.retailer.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                }
            );

            modelBuilder.Entity<ShippingAddress>().HasData(
                new ShippingAddress
                {
                    Id = 1,
                    City = "Warszawa",
                    Country = "Poland",
                    AddressLine1 = "Plac Europejski 1",
                    Postcode = "00-839",
                    Default = true,
                    UserId = 1 
                }
            );

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = 1,
                    CardNumber = "7184 7184 7184 7184",
                    Alias = "Mastercard/EuroCard",
                    Default = true,
                    UserId = 1
                }
            );
        }
    }
}
