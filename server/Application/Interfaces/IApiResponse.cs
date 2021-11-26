namespace Application.Interfaces
{
    public interface IApiResponse
    {
        bool Success { get; set; }

        IApiError Error { get; set; }
    }

    public interface IApiResponse<T> : IApiResponse
    {
        T Data { get; set; }
    }
}
