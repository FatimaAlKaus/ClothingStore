namespace Application.Queries.Product
{
    using System.Linq.Dynamic.Core;
    using Application.DTO.Response;
    using Application.QueryParameters;
    using MediatR;

    public class GetProductListQuery : IRequest<PagedResult<ProductDto>>
    {
        public ProductsQueryParameters Parameters { get; init; }
    }
}
