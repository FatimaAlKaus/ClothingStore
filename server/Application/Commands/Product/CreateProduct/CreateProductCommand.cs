namespace Application.Commands.Product.CreateProduct
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class CreateProductCommand : IRequest<ApiResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
