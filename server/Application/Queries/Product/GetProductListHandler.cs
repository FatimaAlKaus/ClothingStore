namespace Application.Queries.Product
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Common;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public class GetProductListHandler : IRequestHandler<GetProductListQuery, ApiResponse<PagedResult<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<PagedResult<ProductDto>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pagedResult = await DefaulQueryApplyer.GetPagedResult(request.Parameters, _productRepository.GetAsQueryable());
                return new PagedResult<ProductDto>
                {
                    PageCount = pagedResult.PageCount,
                    PageSize = pagedResult.PageSize,
                    CurrentPage = pagedResult.CurrentPage,
                    RowCount = pagedResult.RowCount,
                    Queryable = pagedResult.Queryable.Select(x => x.Adapt<ProductDto>()),
                };
            }
            catch (ArgumentException ex)
            {
                return ApiError.BadReqeust(ex.Message);
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Server error");
            }
        }
    }
}
