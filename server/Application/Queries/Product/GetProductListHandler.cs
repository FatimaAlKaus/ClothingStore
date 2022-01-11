namespace Application.Queries.Product
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetProductListHandler : IRequestHandler<GetProductListQuery, PagedResult<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResult<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var filter = request.Parameters.Filter;
            var orderBy = request.Parameters.OrderBy;
            var takenNumber = request.Parameters.PageSize;
            var skippedNumber = (request.Parameters.PageNumber - 1) * request.Parameters.PageSize;
            var products = _productRepository.GetAsQueryable();

            if (!(string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter)))
            {
                products = products.Where(filter);
            }

            var totalItems = await products.CountAsync();

            if (!(string.IsNullOrEmpty(orderBy) || string.IsNullOrWhiteSpace(orderBy)))
            {
                products = products.OrderBy(orderBy);
            }

            products = products.Skip(skippedNumber).Take(takenNumber);

            var result = products.Select(x => x.Adapt<ProductDto>());
            return new PagedResult<ProductDto>()
            {
                PageCount = (totalItems + takenNumber - 1) / takenNumber,
                CurrentPage = request.Parameters.PageNumber,
                Queryable = result,
                PageSize = takenNumber,
                RowCount = totalItems,
            };
        }
    }
}
