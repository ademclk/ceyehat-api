using Ceyehat.Application.Common.Errors;
using OneOf;

namespace Ceyehat.Application.Services.Authentication.Interfaces;

public interface IAuthService
{
    Task<AuthResult> Login(string email, string password);
    OneOf<AuthResult, DuplicateEmailError> Register(string email, string password, string firstName, string lastName);
}