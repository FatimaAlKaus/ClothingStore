namespace Application.Error
{
    using System.Text.Json.Serialization;

    public class ApiError
    {
        public ApiError(int statusCode, string code, string message)
        {
            StatusCode = statusCode;
            Code = code;
            Message = message;
        }

        [JsonIgnore]
        public int StatusCode { get; }

        public string Code { get; }

        public string Message { get; }

        public static ApiError InternalServerError(string message) => new (500, "InternalServerError", message);

        public static ApiError NotFound(string resourceName, int id) => new (404, $"{resourceName}NotFound", $"{resourceName} with id {id} not found");

        public static ApiError Conflict(string propName, string resourceName, string propValue) => new (409, $"{propName}Conflict", $"{resourceName} with {propName} = '{propValue}' already exists");
    }
}
