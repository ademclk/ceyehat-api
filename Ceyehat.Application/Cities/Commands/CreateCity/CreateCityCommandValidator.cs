using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace Ceyehat.Application.Cities.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<City>
{
    public CreateCityCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.CountryId).NotEmpty();
        RuleForEach(x => x.Districts).SetValidator(new DistrictCommandValidator());
    }

    public class DistrictCommandValidator : IPropertyValidator<City, District>
    {
        public bool IsValid(ValidationContext<City> context, District value)
        {
            return value.Name != null;
        }

        public string Name => "DistrictCommandValidator";

        public string GetDefaultMessageTemplate(string errorCode)
        {
            return "DistrictCommandValidator";
        }
    }
}