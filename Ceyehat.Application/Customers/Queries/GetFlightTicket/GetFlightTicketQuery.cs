using Ceyehat.Application.Customers.Common;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Queries.GetFlightTicket;

public record GetFlightTicketQuery(
    string? Email) : IRequest<ErrorOr<List<FlightTicketDtoResponse>>>;