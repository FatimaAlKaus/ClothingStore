namespace Application.Commands.Product.CreateProduct
{
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class CreateProductCommand : IRequest<IServiceResult<ProductDto>>
    {
        public string Name { get; set; }
    }
}
