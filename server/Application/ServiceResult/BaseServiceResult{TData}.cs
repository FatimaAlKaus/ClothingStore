namespace Application.ServiceResult
{
    using Application.Interfaces;

    public class BaseServiceResult<TData> : BaseServiceResult, IServiceResult
        where TData : class
    {
        public BaseServiceResult()
              : base()
        {
        }

        public BaseServiceResult(TData data)
            : this()
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}
