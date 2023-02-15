namespace Ceyehat.Contracts.Passengers;

public record CreatePassengerRequest(
    string CustomerId,
    CreateFlightTicketRequest FlightTickets);

public record CreateFlightTicketRequest(
    string FlightId,
    string SeatId,
    CreateBoardingPassRequest? BoardingPass);

public record CreateBoardingPassRequest(
    string? Gate,
    DateTime BoardingTime);