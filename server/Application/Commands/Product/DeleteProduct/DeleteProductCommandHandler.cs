namespace Application.Commands.Product.DeleteProduct
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Interfaces;
    using MediatR;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.Delete(request.Id);
        }
    }
}
