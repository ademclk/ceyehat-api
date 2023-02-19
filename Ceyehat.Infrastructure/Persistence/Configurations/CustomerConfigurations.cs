using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomersTable(builder);
        ConfigureCustomerBookingsTable(builder);
        ConfigureCustomerFlightTicketsTable(builder);
        ConfigureCustomerBoardingPassesTable(builder);
    }

    private void ConfigureCustomerBoardingPassesTable(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsMany(
            f => f.BoardingPasses,
            tb =>
            {
                tb.ToTable("CustomerBoardingPasses");

                tb.HasKey(b => b.Id);
                
                tb.Property(b => b.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        f => f.Value,
                        value => BoardingPassId.Create(value));
                
                tb.Property(b => b.BoardingGate)
                    .HasMaxLength(8);

                tb.Property(b => b.BoardingGroup)
                    .HasMaxLength(2);
                
                tb.Property(b => b.BoardingTime)
                    .HasConversion(
                        f => f,
                        value => value);
                
                tb.Property(b => b.CheckInTime)
                    .HasConversion(
                        f => f,
                        value => value);
            });
    }

    private void ConfigureCustomerFlightTicketsTable(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsMany(
            f => f.FlightTickets,
            tb =>
            {
                tb.ToTable("CustomerFlightTickets");

                tb.HasKey(f => f.Id);
                
                tb.Property(f => f.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        f => f.Value,
                        value => FlightTicketId.Create(value));
                
                tb.Property(f => f.BookingId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        f => f.Value,
                        value => BookingId.Create(value));

                tb.Property(f => f.BoardingPassId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        f => f!.Value,
                        value => BoardingPassId.Create(value));

            });
    }

    private void ConfigureCustomerBookingsTable(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsMany(
            c => c.Bookings,
            bb =>
            {
                bb.ToTable("CustomerBookings");

                bb.WithOwner().HasForeignKey("CustomerId");

                bb.HasKey(b => b.Id);

                bb.Property(b => b.Id)
                    .HasColumnName("BookingId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        b => b.Value,
                        value => BookingId.Create(value));

                bb.Property(b => b.SeatId)
                    .HasColumnName("SeatId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        b => b!.Value,
                        value => SeatId.Create(value));

                bb.Property(b => b.FlightId)
                    .HasColumnName("FlightId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        b => b!.Value,
                        value => FlightId.Create(value));
            });
    }

    private void ConfigureCustomersTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                c => c.Value,
                value => CustomerId.Create(value));

        builder.Property(c => c.Name)
            .HasMaxLength(128);

        builder.Property(c => c.Surname)
            .HasMaxLength(128);

        builder.Property(c => c.Email)
            .HasMaxLength(128);

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(16);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasConversion(
                title => (int)title,
                intValue => (Title)intValue);

        builder.Property(c => c.BirthDate)
            .IsRequired();

        builder.Property(c => c.PassengerType)
            .IsRequired()
            .HasConversion(
                passengerType => (int)passengerType,
                intValue => (PassengerType)intValue);

        builder.Property(c => c.UserId)
            .ValueGeneratedNever()
            .HasConversion(
                c => c!.Value,
                value => UserId.Create(value));
    }
}