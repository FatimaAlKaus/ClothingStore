namespace Application.ServiceResult
{
    using Application.Error;
    using Application.Interfaces;

    public class BaseServiceResult : IServiceResult
    {
        public bool Success { get; set; } = true;

        public ApiError Error { get; set; }
    }
}
