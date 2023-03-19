using Ceyehat.Application.Common.DTOs;
using Ceyehat.Domain.FlightAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
    Task<List<FlightDto>> SearchFlightsAsync(
        string departureAirportIataCode,
        string arrivalAirportIataCode,
        DateTime? departureDate,
        DateTime? returnDate,
        int passengerCount);
    Task<List<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
}