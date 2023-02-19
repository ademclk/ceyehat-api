using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PriceAggregate;
using Ceyehat.Domain.PriceAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class PriceConfigurations : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        ConfigurePricesTable(builder);
        ConfigureFlightPricingTable(builder);
    }

    private void ConfigureFlightPricingTable(EntityTypeBuilder<Price> builder)
    {
        builder.OwnsOne(
            p => p.FlightPricing,
            pb =>
            {
                pb.ToTable("FlightPricing");
                
                pb.WithOwner().HasForeignKey("PriceId");
                
                pb.HasKey("Id", "PriceId");
                
                pb.Property(p => p.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => FlightPricingId.Create(value));
                
                pb.Property(p => p.BaseCost)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.MarkupPercentage)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.DemandMultiplier)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.CompetitionMultiplier)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.SeasonalMultiplier)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.LengthMultiplier)
                    .HasColumnType("decimal(10,2)");
                
                pb.Property(p => p.ClassMultiplier)
                    .HasColumnType("decimal(10,2)");
            });
    }

    private void ConfigurePricesTable(EntityTypeBuilder<Price> builder)
    {
        
        builder.ToTable("Prices");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                p => p.Value,
                value => PriceId.Create(value));
        
        builder.Property(p => p.Amount)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(p => p.Currency)
            .HasMaxLength(3)
            .HasConversion(
                currency => (int)currency,
                intValue => (Currency)intValue);
    }
}