namespace Ceyehat.Contracts.Customers.Users;

public record GetFlightTicketResponse(
    string? Id,
    string? Name,
    string? Surname,
    string? FlightNumber,
    string? DepartureIata,
    string? DepartureName,
    string? ArrivalIata,
    string? ArrivalName,
    string? DepartureDate,
    string? ArrivalDate,
    string? DepartureTime,
    string? ArrivalTime,
    string? SeatNumber,
    string? Price,
    string? Currency,
    string? Status);