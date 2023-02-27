using Ceyehat.Application.Airports.Commands.CreateAirport;
using Ceyehat.Application.Airports.Queries.GetAirports;
using Ceyehat.Contracts.Airports;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class AirportController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AirportController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAirport(CreateAirportRequest request)
    {
        var command = _mapper.Map<CreateAirportCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            airport => Ok(_mapper.Map<AirportResponse>(airport)),
            error => Problem(error));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAirports()
    {
        var result = await _mediator.Send(new GetAirportsQuery());
        return result.Match<IActionResult>(
            airports => Ok(_mapper.Map<List<AirportResponse>>(airports)),
            error => Problem(error));
    }

    
}