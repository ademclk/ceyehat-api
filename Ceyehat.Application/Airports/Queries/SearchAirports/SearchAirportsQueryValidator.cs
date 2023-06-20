using FluentValidation;

namespace Ceyehat.Application.Airports.Queries.SearchAirports;

public class SearchAirportsQueryValidator : AbstractValidator<SearchAirportsQuery>
{
    public SearchAirportsQueryValidator()
    {
        RuleFor(a => a.SearchTerm)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .When(a => a.SearchTerm != null)
            .WithMessage("The searchTerm field cannot be empty.");
    }
}