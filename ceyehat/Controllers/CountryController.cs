using Ceyehat.Application.Countries.Commands.CreateCountry;
using Ceyehat.Contracts.Countries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class CountryController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CountryController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountryAsync(
        CreateCountryRequest request)
    {
        var command = _mapper.Map<CreateCountryCommand>(request);

        var createCountryResult = await _mediator.Send(command);

        return createCountryResult.Match<IActionResult>(
            country => Ok(_mapper.Map<CountryResponse>(country)),
            Problem);
    }
}