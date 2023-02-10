using FluentValidation;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
{
    public CreateAircraftCommandValidator()
    {
        RuleFor(v => v.RegistrationNumber)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Icao24Code)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.Model)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.ManufacturerSerialNumber)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.FaaRegistration)
            .MaximumLength(64)
            .NotEmpty();
        RuleFor(v => v.AirlineId)
            .NotEmpty();
        RuleFor(v => v.CountryId)
            .NotEmpty();
    }
}