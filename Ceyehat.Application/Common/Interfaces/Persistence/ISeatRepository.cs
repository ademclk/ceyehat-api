using Ceyehat.Application.Common.DTOs;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ISeatRepository
{
    Task<Seat?> GetSeatByIdAsync(SeatId seatId);
    Task<List<SeatDto>> GetSeatsAsync(string flightNumber, string aircraftName);
    Task AddSeatAsync(Seat seat);
    Task<SeatId?> GetSeatIdByFlightIdAndSeatNumberAsync(FlightId flightId, string seatNumber);
}