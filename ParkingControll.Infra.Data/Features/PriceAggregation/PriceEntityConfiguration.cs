using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingControll.Domain.Features.PriceAggregation;

namespace ParkingControll.Infra.Data.Features.Prices
{
    public class PriceEntityConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");

            builder.HasKey(price => price.Id);
            builder.Property(price => price.Tolerance).IsRequired();
            builder.Property(price => price.Additional).IsRequired();
            builder.Property(price => price.Removed).IsRequired();
            builder.Property(price => price.Initial).IsRequired();
            builder.Property(price => price.Final).IsRequired();
        }
    }
}
