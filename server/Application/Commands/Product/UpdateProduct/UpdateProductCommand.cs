namespace Application.Commands.Product.UpdateProduct
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class UpdateProductCommand : IRequest<ApiResponse<ProductDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int[] Categories { get; set; }
    }
}
