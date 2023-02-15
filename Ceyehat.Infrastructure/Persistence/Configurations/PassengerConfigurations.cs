using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.PassengerAggregate.Entities;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class PassengerConfigurations : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        ConfigurePassengersTable(builder);
        ConfigurePassengerFlightTicketsTable(builder);
        ConfigurePassengerBoardingPassesTable(builder);
    }

    private void ConfigurePassengerBoardingPassesTable(EntityTypeBuilder<Passenger> builder)
    {
        builder.OwnsMany(
            p => p.BoardingPasses,
            tb =>
            {
                tb.ToTable("PassengerBoardingPasses");

                tb.HasKey(b => b.Id);

                tb.Property(b => b.Id)
                    .HasColumnName("PassengerBoardingPassId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => BoardingPassId.Create(value));

                tb.Property(b => b.FlightTicketId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => FlightTicketId.Create(value));

                tb.Property(b => b.Gate)
                    .HasMaxLength(8);

                tb.Property(b => b.BoardingTime)
                    .IsRequired();
            });
    }

    private void ConfigurePassengerFlightTicketsTable(EntityTypeBuilder<Passenger> builder)
    {
        builder.OwnsMany(
            p => p.FlightTickets,
            tb =>
            {
                tb.ToTable("PassengerFlightTickets");

                tb.Property(t => t.Id)
                    .HasColumnName("PassengerFlightTicketId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => FlightTicketId.Create(value));

                tb.Property(t => t.BookingId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => BookingId.Create(value));
            });
    }

    private void ConfigurePassengersTable(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("Passengers");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                p => p.Value,
                value => PassengerId.Create(value));

        builder.Property(p => p.CustomerId)
            .ValueGeneratedNever()
            .HasConversion(
                p => p.Value,
                value => CustomerId.Create(value));

    }
}