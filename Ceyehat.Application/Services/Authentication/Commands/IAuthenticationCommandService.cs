using Ceyehat.Application.Services.Authentication.Common;
using ErrorOr;

namespace Ceyehat.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{ 
    ErrorOr<AuthenticationResult> Register(string email, string password, string firstName, string lastName);
}