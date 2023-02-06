namespace Ceyehat.Domain.Entities;

public class Passenger
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public ICollection<BoardingPass> BoardingPasses { get; set; } = null!;
    public ICollection<Relationship> Relationships { get; set; } = null!;
    public ICollection<FlightTicket> FlightTickets { get; set; } = null!;
}