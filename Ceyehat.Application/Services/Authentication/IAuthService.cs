using Ceyehat.Application.Common.Errors;
using FluentResults;

namespace Ceyehat.Application.Services.Authentication.Interfaces;

public interface IAuthService
{
    Task<AuthResult> Login(string email, string password);
    Result<AuthResult> Register(string email, string password, string firstName, string lastName);
}