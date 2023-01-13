using Ceyehat.Application.Services.Authentication.Common;
using ErrorOr;

namespace Ceyehat.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}