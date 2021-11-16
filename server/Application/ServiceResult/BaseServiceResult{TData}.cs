namespace Application.ServiceResult
{
    using Application.Interfaces;

    public class BaseServiceResult<TData> : BaseServiceResult, IServiceResult
        where TData : class
    {
        public BaseServiceResult()
        {
        }

        public BaseServiceResult(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}
