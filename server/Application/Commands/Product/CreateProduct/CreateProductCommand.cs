namespace Application.Commands.Product.CreateProduct
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class CreateProductCommand : IRequest<ApiResponse<ProductDto>>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int[] Categories { get; set; }

        public IFormFile File { get; set; }
    }
}
