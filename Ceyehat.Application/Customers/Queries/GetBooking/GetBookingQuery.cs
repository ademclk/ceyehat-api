using Ceyehat.Application.Customers.Common;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Queries.GetBooking;

public record GetBookingQuery(
    string? Email) : IRequest<ErrorOr<List<BookingDtoResponse>>>;