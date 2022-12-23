namespace Ceyehat.Application.Services.Authentication.Interfaces;

public interface IAuthService
{
    AuthResult Login(string email, string password);
    AuthResult Register(string email, string password, string firstName, string lastName);
}