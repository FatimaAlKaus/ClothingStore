namespace Application.Queries.Product
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class GetProductByIdQuery : IRequest<ApiResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
