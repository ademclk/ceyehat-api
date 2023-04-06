using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly CeyehatDbContext _dbContext;

    public SeatRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SeatDto>> GetSeatsAsync(string flightNumber, string aircraftName)
    {
        var seats = await (
            from seat in _dbContext.Seats
            join flight in _dbContext.Flights on seat.FlightId equals flight.Id
            join aircraft in _dbContext.Aircrafts on flight.AircraftId equals aircraft.Id
            select new SeatDto
            {
                SeatNumber = seat.SeatNumber,
                SeatClass = seat.SeatClass,
                SeatStatus = seat.SeatStatus
            }
        ).ToListAsync();
        
        return seats;
    }

    public async Task AddSeatAsync(Seat seat)
    {
        await _dbContext.Seats.AddAsync(seat);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<SeatId?> GetSeatIdByFlightIdAndSeatNumberAsync(FlightId flightId, string seatNumber)
    {
        var seat = await _dbContext.Seats
            .FirstOrDefaultAsync(s => s.FlightId == flightId && s.SeatNumber == seatNumber);
        return seat?.Id;
    }
}