using Ceyehat.Contracts.Authentication;

namespace Ceyehat.Application.Services.Authentication.Interfaces;

public interface IAuthService
{
    Task<Token> Login(string email, string password);
    Task<Token> Register(string email, string password, string firstName, string lastName);
}