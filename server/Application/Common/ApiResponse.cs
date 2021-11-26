namespace Application.ApiResponse
{
    using Application.Interfaces;

    public class ApiResponse : IApiResponse
    {
        public bool Success { get; set; } = true;

        public IApiError Error { get; set; }

        public static implicit operator ApiResponse(ApiError error) => new ApiResponse() { Success = false, Error = error };
    }
}
