namespace Application.Queries.Product
{
    using System.Collections.Generic;
    using Application.DTO.Response;
    using MediatR;

    public class GetProductListQuery : IRequest<List<ProductDto>>
    {
    }
}
