using Ceyehat.Application.Flights.Commands;
using Ceyehat.Contracts.Flights;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
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
        CreateFlightRequest request)
    {
        var command = _mapper.Map<CreateFlightCommand>(request);

        var createFlightResult = await _mediator.Send(command);

        return createFlightResult.Match<IActionResult>(
            flight => Ok(_mapper.Map<FlightResponse>(flight)),
            error => Problem(error));
    }
}