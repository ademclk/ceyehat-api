using FluentValidation;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
{
    public CreateAircraftCommandValidator()
    {
        RuleFor(x => x.RegistrationNumber).NotEmpty();
        RuleFor(x => x.Icao24Code).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.ManufacturerSerialNumber).NotEmpty();
        RuleFor(x => x.FaaRegistration).NotEmpty();
    }
}