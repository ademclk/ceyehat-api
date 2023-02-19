using Ceyehat.Contracts.Cities;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neighborhood = Ceyehat.Domain.CityAggregate.Entities.Neighborhood;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class CityConfigurations : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        ConfigureCitiesTable(builder);
        ConfigureCityDistrictsTable(builder);
    }

    private void ConfigureCityDistrictsTable(EntityTypeBuilder<City> builder)
    {
        builder.OwnsMany(
            c => c.Districts,
            db =>
            {
                db.ToTable("Districts");

                db.HasKey(d => d.Id);

                db.Property(d => d.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        d => d.Value,
                        value => DistrictId.Create(value));

                db.Property(d => d.Name)
                    .HasMaxLength(256);

                db.OwnsMany(d => d.Neighborhoods, db =>
                {
                    db.ToTable("Neighborhoods");

                    db.HasKey(n => n.Id);

                    db.Property(n => n.Id)
                        .ValueGeneratedNever()
                        .HasConversion(
                            n => n.Value,
                            value => NeighborhoodId.Create(value));

                    db.Property(n => n.Name)
                        .HasMaxLength(256);

                    db.Property(n => n.AirlineId)
                        .ValueGeneratedNever()
                        .HasConversion(
                            n => n!.Value,
                            value => AirlineId.Create(value));

                    db.Property(n => n.AirportId)
                        .ValueGeneratedNever()
                        .HasConversion(
                            n => n!.Value,
                            value => AirportId.Create(value));

                });

                db.Navigation(d => d.Neighborhoods).Metadata.SetField("_neighborhoods");
                db.Navigation(d => d.Neighborhoods).UsePropertyAccessMode(PropertyAccessMode.Field);
                
            });
        
        builder.Metadata.FindNavigation(nameof(City.Districts))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCitiesTable(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                c => c.Value,
                value => CityId.Create(value));

        builder.Property(c => c.Name)
            .HasMaxLength(128);

        builder.Property(c => c.CountryId)
            .ValueGeneratedNever()
            .HasConversion(
                c => c.Value,
                value => CountryId.Create(value));

    }
}