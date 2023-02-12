using System.Collections.Immutable;
using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        ConfigureCountriesTable(builder);
        ConfigureCountryAircraftIdsTable(builder);
        ConfigureCountryAirlineIdsTable(builder);
        ConfigureCountryCityIdsTable(builder);
    }

    private void ConfigureCountryCityIdsTable(EntityTypeBuilder<Country> builder)
    {
        builder.OwnsMany(
            c => c.CityIds,
            cib =>
            {
                cib.ToTable("CountryCityIds");
                
                cib.WithOwner().HasForeignKey("CountryId");
                
                cib.HasKey("Id");
                
                cib.Property(c => c.Value)
                    .HasColumnName("CityId")
                    .ValueGeneratedNever();
            });
        
        builder.Metadata.FindNavigation(nameof(Country.CityIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCountryAirlineIdsTable(EntityTypeBuilder<Country> builder)
    {
        builder.OwnsMany(
            c => c.AirlineIds,
            aib =>
            {
                aib.ToTable("CountryAirlineIds");
                
                aib.WithOwner().HasForeignKey("CountryId");
                
                aib.HasKey("Id");
                
                aib.Property(a => a.Value)
                    .HasColumnName("AirlineId")
                    .ValueGeneratedNever();
            });
        
        builder.Metadata.FindNavigation(nameof(Country.AirlineIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCountryAircraftIdsTable(EntityTypeBuilder<Country> builder)
    {
        builder.OwnsMany(
            c => c.AircraftIds, 
            aib =>
        {
            aib.ToTable("CountryAircraftIds");

            aib.WithOwner().HasForeignKey("CountryId");

            aib.HasKey("Id");

            aib.Property(a => a.Value)
                .HasColumnName("AircraftId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Country.AircraftIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCountriesTable(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                c => c.Value,
                value => CountryId.Create(value));

        builder.Property(c => c.UnLocode)
            .HasMaxLength(16);

        builder.Property(c => c.Name)
            .HasMaxLength(128);

        builder.Property(c => c.Iso2)
            .HasMaxLength(2);

        builder.Property(c => c.Iso3)
            .HasMaxLength(3);

        builder.Property(c => c.Currency)
            .HasConversion(
                currency => (int)currency,
                intValue => (Currency)intValue);
    }
}