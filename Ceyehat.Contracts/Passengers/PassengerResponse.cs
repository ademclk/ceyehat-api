namespace Ceyehat.Contracts.Passengers;

public record PassengerResponse(
    string Id,
    string CustomerId,
    List<FlightTicketResponse> FlightTickets);

public record FlightTicketResponse(
    string Id,
    string FlightId,
    string SeatId,
    BoardingPassResponse? BoardingPass);

public record BoardingPassResponse(
    string Id,
    string? Gate,
    DateTime BoardingTime);