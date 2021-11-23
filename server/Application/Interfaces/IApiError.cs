namespace Application.Interfaces
{
    using System.Net;

    public interface IApiError
    {
        HttpStatusCode StatusCode { get; }

        string Code { get; }

        string Message { get; }
    }
}
