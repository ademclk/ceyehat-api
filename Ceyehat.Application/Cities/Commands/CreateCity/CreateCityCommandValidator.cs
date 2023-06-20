using Ceyehat.Domain.CityAggregate;
using FluentValidation;

namespace Ceyehat.Application.Cities.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<City>
{
    public CreateCityCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.CountryId).NotEmpty();
    }
}