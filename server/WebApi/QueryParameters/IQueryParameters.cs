namespace WebApi.QueryParameters
{
    internal interface IQueryParameters
    {
        int PageNumber { get; init; }

        int PageSize { get; init; }

        string OrderBy { get; init; }

        string Filter { get; init; }
    }
}
