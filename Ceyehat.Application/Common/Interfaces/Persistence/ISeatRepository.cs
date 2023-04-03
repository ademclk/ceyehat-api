using Ceyehat.Application.Common.DTOs;
using Ceyehat.Domain.SeatAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ISeatRepository
{
    Task<List<SeatDto>> GetSeatsAsync(string flightNumber, string aircraftName);
    Task AddSeatAsync(Seat seat);
}