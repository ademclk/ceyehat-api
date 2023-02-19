using Ceyehat.Domain.SeatAggregate;
using FluentValidation;

namespace Ceyehat.Application.Seats.Commands.CreateSeat;

public class CreateSeatCommandValidator : AbstractValidator<Seat>
{
    public CreateSeatCommandValidator()
    {
        RuleFor(x => x.SeatNumber)
            .NotEmpty();
        RuleFor(x => x.SeatClass)
            .NotEmpty();
        RuleFor(x => x.SeatStatus)
            .NotEmpty();
        RuleFor(x => x.AircraftId)
            .NotEmpty();
    }
}