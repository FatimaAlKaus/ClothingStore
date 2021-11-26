namespace Application.Queries.Product
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _productRepository.GetById(request.Id);
            if (model is null)
            {
                return ApiError.NotFound(nameof(Domain.Models.Product), request.Id);
            }

            return model.Adapt<ProductDto>();
        }
    }
}
