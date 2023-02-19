using Ceyehat.Application.Seats.Commands;
using Ceyehat.Application.Seats.Commands.CreateSeat;
using Ceyehat.Contracts.Seats;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
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
            error => Problem(error));
    }
}