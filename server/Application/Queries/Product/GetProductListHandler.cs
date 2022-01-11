namespace Application.Queries.Product
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

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
                var filter = request.Parameters.Filter;
                var orderBy = request.Parameters.OrderBy;
                var takenNumber = request.Parameters.PageSize;
                var skippedNumber = (request.Parameters.PageNumber - 1) * request.Parameters.PageSize;
                var products = _productRepository.GetAsQueryable();

                if (!(string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter)))
                {
                    try
                    {
                        products = products.Where(filter);
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid argument", nameof(filter));
                    }
                }

                var totalItems = await products.CountAsync();

                if (!(string.IsNullOrEmpty(orderBy) || string.IsNullOrWhiteSpace(orderBy)))
                {
                    try
                    {
                        products = products.OrderBy(orderBy);
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid argument", nameof(orderBy));
                    }
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
