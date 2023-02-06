namespace Ceyehat.Domain.Entities;

public class BoardingPass
{
    public Guid Id { get; set; }
    public Guid FlightTicketId { get; set; }
    public string BoardingPassNumber { get; set; } = null!;

    public FlightTicket FlightTicket { get; set; } = null!;
}