using MediatR;
using ErrorOr;

namespace Ceyehat.Contracts.Customers.Users;

public record GetFlightTicketRequest(
    string? Email);