using Ceyehat.Application.Aircrafts.Commands.CreateAircraft;
using Ceyehat.Contracts.Aircrafts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class AircraftController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AircraftController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAircraftAsync(
        CreateAircraftRequest request)
    {
        var command = _mapper.Map<CreateAircraftCommand>(request);

        var createAircraftResult = await _mediator.Send(command);

        return createAircraftResult.Match<IActionResult>(
            aircraft => Ok(_mapper.Map<AircraftResponse>(aircraft)),
            Problem);
    }
}