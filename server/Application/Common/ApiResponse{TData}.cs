namespace Application.ApiResponse
{
    using Application.Interfaces;

    public class ApiResponse<TData> : ApiResponse, IApiResponse<TData>
        where TData : class
    {
        public ApiResponse()
        {
        }

        public ApiResponse(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }

        public static implicit operator ApiResponse<TData>(TData data) => new ApiResponse<TData>() { Success = true, Data = data };

        public static implicit operator ApiResponse<TData>(ApiError error) => new ApiResponse<TData>() { Success = false, Data = null, Error = error };
    }
}
