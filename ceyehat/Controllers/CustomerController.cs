using System.Text;
using Ceyehat.Application.Customers.Commands;
using Ceyehat.Application.Customers.Commands.AddPassenger;
using Ceyehat.Application.Customers.Commands.CreateCustomer;
using Ceyehat.Application.Customers.Commands.CreateTicket;
using Ceyehat.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ceyehat.Common.Services;
using Ceyehat.Domain.CustomerAggregate;


namespace ceyehat.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class CustomerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly EmailService _emailService;

    public CustomerController(IMapper mapper, IMediator mediator, EmailService emailService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _emailService = emailService;
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

    [HttpPost("add-passenger")]
    public async Task<IActionResult> AddPassengerAsync(
        AddPassengerRequest request)
    {
        var command = _mapper.Map<AddPassengerCommand>(request);

        var addPassengerResult = await _mediator.Send(command);

        return addPassengerResult.Match<IActionResult>(
            customer => Ok(_mapper.Map<CustomerResponse>(customer)),
            error => Problem(error));
    }

    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicketAsync(CreateTicketRequest request)
    {
        var command = _mapper.Map<CreateTicketCommand>(request);

        var createTicketResult = await _mediator.Send(command);

        return await createTicketResult.MatchAsync<IActionResult>(
            async ticket => await HandleTicketCreationSuccess(ticket),
            error => Task.FromResult<IActionResult>(Problem(error)));
    }

    private async Task<IActionResult> HandleTicketCreationSuccess(Customer ticket)
    {
        var customerResponse = _mapper.Map<CustomerResponse>(ticket);
        await SendEmailToCustomer(customerResponse);
        return Ok(customerResponse);
    }

    private async Task SendEmailToCustomer(CustomerResponse customer)
    {
        var subject = "Your ticket information";
        var content = GenerateTicketEmailContent(customer);
        await _emailService.SendEmailAsync(customer.Email!.ToLower(), subject, content);
    }

    private string GenerateTicketEmailContent(CustomerResponse customer)
    {
        var sb = new StringBuilder();

        sb.AppendLine("<html>");
        sb.AppendLine("<body>");
        sb.AppendLine("<p>Merhaba <strong>" + customer.Name + " " + customer.Surname + "</strong>,</p>");
        sb.AppendLine("<p>Bilet bilgileriniz aşağıdaki gibidir:</p>");

        sb.AppendLine("<ul>");

        sb.AppendLine("<li>");
        sb.AppendLine("<p>Uçuş ID: <strong>" + customer.FlightTickets[0].Id + "</strong></p>");
        sb.AppendLine("<p>Rezervasyon ID: <strong>" + customer.FlightTickets[0].BookingId + "</strong></p>");
        sb.AppendLine("</li>");

        sb.AppendLine("</ul>");

        sb.AppendLine("<p>İyi yolculuklar dileriz.</p>");
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");

        return sb.ToString();
    }
}