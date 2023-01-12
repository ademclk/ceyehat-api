using FluentResults;

namespace Ceyehat.Application.Services.Authentication;

public interface IAuthService
{
    Task<AuthResult> Login(string email, string password);
    Result<AuthResult> Register(string email, string password, string firstName, string lastName);
}