namespace Ceyehat.Application.Services.Authentication.Interfaces;

public interface IAuthService
{
    Task<AuthResult> Login(string email, string password);
    Task<AuthResult> Register(string email, string password, string firstName, string lastName);
}