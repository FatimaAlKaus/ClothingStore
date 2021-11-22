namespace Application.Commands.Product.CreateProduct
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductDto>>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ApiResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.CreateProduct(request);
        }
    }
}
