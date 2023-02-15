using Ceyehat.Application.Passengers.Commands;
using Ceyehat.Contracts.Passengers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class PassengerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    
    public PassengerController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePassengerAsync(
        CreatePassengerRequest request)
    {
        var command = _mapper.Map<CreatePassengerCommand>(request);
        
        var createPassengerResult = await _sender.Send(command);
        
        return createPassengerResult.Match<IActionResult>(
            passenger => Ok(_mapper.Map<PassengerResponse>(passenger)),
            error => Problem(error));
    }
}