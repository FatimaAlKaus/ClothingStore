namespace Application.Commands.Product.CreateProduct
{
    using System.IO;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class CreateProductCommand : IRequest<ApiResponse<ProductDto>>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int[] Categories { get; set; }

        public Stream File { get; set; }

        public string FileFormat { get; set; }
    }
}
