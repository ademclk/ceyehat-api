using Ceyehat.Application.Customers.Commands;
using Ceyehat.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class CustomerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CustomerController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(
        CreateCustomerRequest request)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);

        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match<IActionResult>(
            customer => Ok(_mapper.Map<CustomerResponse>(customer)),
            error => Problem(error));
    }
}