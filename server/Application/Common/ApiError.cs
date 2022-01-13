namespace Application.ApiResponse
{
    using System.Net;
    using System.Text.Json.Serialization;
    using Application.Interfaces;

    public class ApiError : IApiError
    {
        private ApiError(HttpStatusCode statusCode, string code, string message)
        {
            StatusCode = statusCode;
            Code = code;
            Message = message;
        }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; }

        public string Code { get; }

        public string Message { get; }

        public static ApiError InternalServerError(string message) => new (HttpStatusCode.InternalServerError, "InternalServerError", message);

        public static ApiError BadReqeust(string message) => new (HttpStatusCode.BadRequest, "BadRequest", message);

        public static ApiError NotFound(string resourceName, int id) => new (HttpStatusCode.NotFound, $"{resourceName}NotFound", $"{resourceName} with id {id} not found");

        public static ApiError Conflict(string propName, string resourceName, string propValue) => new (HttpStatusCode.Conflict, $"{propName}Conflict", $"{resourceName} with {propName} = '{propValue}' already exists");
    }
}
