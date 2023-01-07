using System.Net;
using Ceyehat.Application.Common.Errors.Interfaces;

namespace Ceyehat.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "An user with this email already exists.";
}