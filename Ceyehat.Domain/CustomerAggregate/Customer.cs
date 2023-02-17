using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.Entities;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate;

public sealed class Customer : AggregateRoot<CustomerId>
{
    private readonly List<Booking> _bookings = new();

    public string? Name { get; private set; }
    public string? Surname { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public Title Title { get; private set; }
    public DateTime BirthDate { get; private set; }
    public PassengerType PassengerType { get; private set; }

    public UserId? UserId { get; private set; }
    public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Customer(
        CustomerId customerId,
        string? name,
        string? surname,
        string? email,
        string? phoneNumber,
        Title title,
        DateTime birthDate,
        PassengerType passengerType,
        UserId? userId,
        DateTime createdAt,
        DateTime updatedAt) : base(customerId)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        Title = title;
        BirthDate = birthDate;
        PassengerType = passengerType;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Customer Create(
        string? name,
        string? surname,
        string? email,
        string? phoneNumber,
        Title title,
        DateTime birthDate,
        PassengerType passengerType,
        UserId? userId)
    {
        return new(
            CustomerId.CreateUnique(),
            name,
            surname,
            email,
            phoneNumber,
            title,
            birthDate,
            passengerType,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
    
    public void AddBooking(Booking booking)
    {
        _bookings.Add(booking);
    }

    public void RemoveBooking(Booking booking)
    {
        _bookings.Remove(booking);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected Customer()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}