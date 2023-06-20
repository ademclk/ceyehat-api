using Ceyehat.Application.Prices.Command.CreatePrice;
using Ceyehat.Contracts.Prices;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;
[Route("api/[controller]")]
[AllowAnonymous]
public class PriceController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PriceController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePriceAsync(
        CreatePriceRequest request)
    {
        var command = _mapper.Map<CreatePriceCommand>(request);

        var createPriceResult = await _mediator.Send(command);

        return createPriceResult.Match<IActionResult>(
            price => Ok(_mapper.Map<PriceResponse>(price)),
            Problem);
    }


}