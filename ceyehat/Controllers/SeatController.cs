using Ceyehat.Application.Seats.Commands.CreateSeat;
using Ceyehat.Application.Seats.Queries.GetSeats;
using Ceyehat.Contracts.Seats;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class SeatController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public SeatController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeatAsync(CreateSeatRequest request)
    {
        var command = _mapper.Map<CreateSeatCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            seat => Ok(_mapper.Map<SeatResponse>(seat)),
            Problem);
    }

    [HttpGet]
    [Route("{flightNumber}/{aircraftName}")]
    public async Task<IActionResult> GetSeatsAsync(string flightNumber, string aircraftName)
    {
        var query = new GetSeatsQuery(flightNumber, aircraftName);
        var result = await _mediator.Send(query);
        return result.Match(
            Ok,
            Problem);
    }
}