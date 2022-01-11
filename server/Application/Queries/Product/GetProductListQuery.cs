namespace Application.Queries.Product
{
    using System.Linq.Dynamic.Core;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Application.QueryParameters;
    using MediatR;

    public class GetProductListQuery : IRequest<ApiResponse<PagedResult<ProductDto>>>
    {
        public ProductsQueryParameters Parameters { get; init; }
    }
}
