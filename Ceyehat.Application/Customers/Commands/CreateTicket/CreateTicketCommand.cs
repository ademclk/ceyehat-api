using Ceyehat.Domain.CustomerAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Commands.CreateTicket;
public record CreateTicketCommand(
    string? Email,
    string? FlightId
) : IRequest<ErrorOr<Customer>>;