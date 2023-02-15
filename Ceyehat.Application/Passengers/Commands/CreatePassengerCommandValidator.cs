using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.PassengerAggregate.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace Ceyehat.Application.Passengers.Commands;

public class CreatePassengerCommandValidator : AbstractValidator<Passenger>
{
    public CreatePassengerCommandValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty();
    }
}