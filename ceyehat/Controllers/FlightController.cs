using Ceyehat.Application.Flights.Commands;
using Ceyehat.Application.Flights.Commands.CreateFlight;
using Ceyehat.Application.Flights.Common;
using Ceyehat.Application.Flights.Queries.SearchFlights;
using Ceyehat.Contracts.Flights;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class FlightController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public FlightController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFlightAsync(
        [FromBody] CreateFlightRequest request)
    {
        var command = _mapper.Map<CreateFlightCommand>(request);

        var createFlightResult = await _mediator.Send(command);

        return createFlightResult.Match<IActionResult>(
            flight => Ok(_mapper.Map<FlightResponse>(flight)),
            error => Problem(error));
    }
    
    [HttpPost]
    [Route("search")]
    public async Task<IActionResult> SearchFlightsAsync(
        [FromBody] SearchFlightQuery request)
    {
        var searchFlightsResult = await _mediator.Send(new SearchFlightQuery(
            request.DepartureAirportIataCode,
            request.ArrivalAirportIataCode,
            request.DepartureDate,
            request.ReturnDate,
            request.PassengerCount));
        
        return searchFlightsResult.Match<IActionResult>(
            flights => Ok(_mapper.Map<List<FlightDtoResponse>>(flights)),
            error => Problem(error));
    }
}