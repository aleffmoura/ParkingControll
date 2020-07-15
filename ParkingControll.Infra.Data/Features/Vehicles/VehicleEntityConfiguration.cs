using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingControll.Domain.Features.Vehicles;

namespace ParkingControll.Infra.Data.Features.Vehicles
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(price => price.Id);
            builder.Property(price => price.Removed).IsRequired();
            builder.Property(price => price.Plate).IsRequired();
            builder.Property(price => price.CameIn).IsRequired();
            builder.Property(price => price.AmountPaid);
            builder.Property(price => price.Exited);
        }
    }
}
