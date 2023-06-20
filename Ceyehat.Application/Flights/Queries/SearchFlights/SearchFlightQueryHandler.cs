using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Flights.Queries.SearchFlights;

public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, ErrorOr<List<FlightDto>>>
{
    private readonly IFlightRepository _flightRepository;

    public SearchFlightQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<List<FlightDto>>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
    {
        var departureDate = DateTime.Parse(request.DepartureDate!);
        var returnDate = DateTime.Parse(request.ReturnDate!);

        var flights = await _flightRepository.SearchFlightsAsync(
            request.DepartureAirportIataCode!,
            request.ArrivalAirportIataCode!,
            departureDate,
            returnDate,
            request.PassengerCount);

        return flights;
    }
}