using Microsoft.EntityFrameworkCore;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Infra.Data.Features.Prices;
using ParkingControll.Infra.Data.Features.Vehicles;

namespace ParkingControll.Infra.Data.Contexts
{
    public class ParkingContext : DbContext
    {
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Price> Prices { get; set; }

        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PriceEntityConfiguration());

            //modelBuilder.SeedAuth();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }
    }
}
