using ErrorOr;

namespace Ceyehat.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string email, string password, string firstName, string lastName);
}