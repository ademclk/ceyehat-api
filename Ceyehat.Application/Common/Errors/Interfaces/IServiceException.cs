using System.Net;

namespace Ceyehat.Application.Common.Errors.Interfaces;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}