using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate;

public sealed class Customer : AggregateRoot<CustomerId>
{
    private readonly List<PassengerId> _passengerIds = new();
    private readonly List<BookingId> _bookingIds = new();

    public string? Name { get; }
    public string? Surname { get; }
    public string? Email { get; }
    public Title Title { get; }
    public DateTime BirthDate { get; }
    public PassengerType PassengerType { get; }

    public UserId? UserId { get; }
    public IReadOnlyCollection<PassengerId> PassengerIds => _passengerIds.AsReadOnly();
    public IReadOnlyCollection<BookingId> BookingIds => _bookingIds.AsReadOnly();

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Customer(
        CustomerId customerId,
        string? name,
        string? surname,
        string? email,
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
            title,
            birthDate,
            passengerType,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddPassenger(PassengerId passengerId)
    {
        _passengerIds.Add(passengerId);
    }

    public void RemovePassenger(PassengerId passengerId)
    {
        _passengerIds.Remove(passengerId);
    }

    public void AddBooking(BookingId bookingId)
    {
        _bookingIds.Add(bookingId);
    }

    public void RemoveBooking(BookingId bookingId)
    {
        _bookingIds.Remove(bookingId);
    }
}