using Ceyehat.Application.Customers.Commands.AddPassenger;
using Ceyehat.Application.Customers.Commands.CreateCustomer;
using Ceyehat.Application.Customers.Commands.CreateTicket;
using Ceyehat.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ceyehat.Domain.CustomerAggregate;


namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
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
            Problem);
    }

    [HttpPost("add-passenger")]
    public async Task<IActionResult> AddPassengerAsync(
        AddPassengerRequest request)
    {
        var command = _mapper.Map<AddPassengerCommand>(request);

        var addPassengerResult = await _mediator.Send(command);

        return addPassengerResult.Match<IActionResult>(
            customer => Ok(_mapper.Map<CustomerResponse>(customer)),
            Problem);
    }

    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicketAsync(CreateTicketRequest request)
    {
        var command = _mapper.Map<CreateTicketCommand>(request);

        var createTicketResult = await _mediator.Send(command);

        return await createTicketResult.MatchAsync<IActionResult>(
            async ticket => await HandleTicketCreationSuccess(ticket),
            error => Task.FromResult(Problem(error)));
    }

    private Task<IActionResult> HandleTicketCreationSuccess(Customer ticket)
    {
        var customerResponse = _mapper.Map<CustomerResponse>(ticket);
        return Task.FromResult<IActionResult>(Ok(customerResponse));
    }
}