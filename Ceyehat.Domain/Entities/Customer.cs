using Ceyehat.Domain.Entities;

namespace Ceyehat.Domain.User;

public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public Passenger Passenger { get; set; } = null!;
    public User User { get; set; } = null!;
    public List<Booking> Bookings { get; set; } = null!;
}