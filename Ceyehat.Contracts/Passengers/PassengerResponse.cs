namespace Ceyehat.Contracts.Passengers;

public record PassengerResponse(
    string Id,
    string CustomerId,
    List<FlightTicketResponse> FlightTickets,
    List<BoardingPassResponse> BoardingPasses);

public record FlightTicketResponse(
    string Id,
    string BookingId);

public record BoardingPassResponse(
    string Id,
    string FlightTicketId,
    string? Gate,
    DateTime BoardingTime);