namespace Application.Interfaces
{
    using Application.Error;

    public interface IServiceResult
    {
        bool Success { get; set; }

        ApiError Error { get; set; }
    }
}
