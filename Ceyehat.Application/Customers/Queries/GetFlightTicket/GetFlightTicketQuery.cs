using Ceyehat.Application.Customers.Common;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Queries.GetFlightTicket;

public abstract record GetFlightTicketQuery(
    string? Email) : IRequest<ErrorOr<List<FlightTicketDtoResponse>>>;