using Ceyehat.Application.Cities.Commands.CreateCity;
using Ceyehat.Contracts.Cities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class CityController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CityController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCityAsync(
        CreateCityRequest request)
    {
        var command = _mapper.Map<CreateCityCommand>(request);

        var createCityResult = await _mediator.Send(command);

        return createCityResult.Match<IActionResult>(
            city => Ok(_mapper.Map<CityResponse>(city)),
            error => Problem(error));
    }
}