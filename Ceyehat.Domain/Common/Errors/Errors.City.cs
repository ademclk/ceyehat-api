using ErrorOr;
namespace Ceyehat.Domain.Common.Errors;


public static partial class Errors
{
    public static class City
    {
        public static Error NotFound => Error.Validation(
            code: "City.CityNotFound",
            description: "City not found");
    }
}