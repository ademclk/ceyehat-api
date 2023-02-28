using ErrorOr;

namespace Ceyehat.Domain.Common.Errors;

public partial class Errors
{
    public static class Country
    {
        public static Error NotFound => Error.Validation(
            code: "Country.CountryNotFound",
            description: "Country not found");
    }
    
}