using Ceyehat.Application.Aircrafts.Commands.CreateAircraft;
using Ceyehat.Contracts.Aircrafts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class AircraftsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;


    public AircraftsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAircraft(
        CreateAircraftRequest request)
    {
        var command = _mapper.Map<CreateAircraftCommand>(request);

        var createAircraftResult = await _mediator.Send(command);

        return createAircraftResult.Match<IActionResult>(
            aircraft => Ok(_mapper.Map<AircraftResponse>(aircraft)),
            error => Problem(error));
    }
}