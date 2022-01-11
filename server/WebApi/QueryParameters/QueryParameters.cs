namespace WebApi.QueryParameters
{
    internal abstract class QueryParameters : IQueryParameters
    {
        private const int MaxPageSize = 999;
        private int _pageSize = 12;
        private int _pageNumber = 1;

        public QueryParameters()
        {
            OrderBy = "modifiedDate";
        }

        public int PageNumber
        {
            get => _pageNumber;

            init => _pageNumber = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;

            init => _pageSize = value switch
            {
                < 1 => 1,
                > MaxPageSize => MaxPageSize,
                _ => value,

            };
        }

        public virtual string OrderBy { get; init; }

        public virtual string Filter { get; init; }
    }
}
