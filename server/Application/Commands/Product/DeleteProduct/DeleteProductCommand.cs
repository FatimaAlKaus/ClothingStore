namespace Application.Commands.Product.DeleteProduct
{
    using Application.ApiResponse;
    using MediatR;

    public class DeleteProductCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
