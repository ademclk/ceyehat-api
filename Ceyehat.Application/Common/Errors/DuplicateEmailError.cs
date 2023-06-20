using FluentResults;

namespace Ceyehat.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public string Message { get; } = null!;
    public Dictionary<string, object> Metadata { get; } = null!;
    public List<IError> Reasons { get; } = null!;
}