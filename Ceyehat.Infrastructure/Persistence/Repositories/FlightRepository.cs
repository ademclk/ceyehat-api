using System.Runtime.CompilerServices;
using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate;
using Ceyehat.Domain.SeatAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly CeyehatDbContext _dbContext;

    public FlightRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<FlightDto>> SearchFlightsAsync(
        string departureAirportIataCode,
        string arrivalAirportIataCode,
        DateTime? departureDate,
        DateTime? returnDate,
        int passengerCount)
    {
        var flights = await (
            from flight in _dbContext.Flights
            join aircraft in _dbContext.Aircrafts on flight.AircraftId equals aircraft.Id
            join airline in _dbContext.Airlines on aircraft.AirlineId equals airline.Id
            // join dAirport in _dbContext.Airports on flight.DepartureAirportId equals dAirport.Id
            // join aAirport in _dbContext.Airports on flight.ArrivalAirportId equals aAirport.Id

            // TODO: TO FILTER RESULTS WHERE CLAUSE SHOULD BE HERE.

            select new FlightDto
            {
                FlightNumber = flight.FlightNumber,
                AirlineName = airline.IcaoCode,
                AircraftName = aircraft.RegistrationNumber,
                DepartureHour = flight.ScheduledDeparture,
                ArrivalHour = flight.ScheduledArrival,
                EconomyPrice = 125.10m,
                ComfortPrice = 145.20m,
                BusinessPrice = 250.30m,
            }).ToListAsync();

        return flights;
    }

    public async Task<List<Flight>> GetAllFlightsAsync()
    {
        var flights = await _dbContext.Flights.ToListAsync();

        return flights;
    }

    public async Task AddFlightAsync(Flight flight)
    {
        await _dbContext.Flights.AddAsync(flight);
        await _dbContext.SaveChangesAsync();
    }
}