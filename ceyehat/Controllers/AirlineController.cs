using Ceyehat.Application.Airlines.Commands.CreateAirline;
using Ceyehat.Contracts.Airlines;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class AirlineController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AirlineController(IMediator mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAirlineAsync(
        CreateAirlineRequest request)
    {
        var command = _mapper.Map<CreateAirlineCommand>(request);

        var createAirlineResult = await _mediator.Send(command);

        return createAirlineResult.Match<IActionResult>(
            airline => Ok(_mapper.Map<AirlineResponse>(airline)),
            Problem);
    }
}