namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using Application.Commands.Product.CreateProduct;
    using Application.DTO.Response;

    public interface IProductService
    {
        Task<IServiceResult<ProductDto>> CreateProduct(CreateProductCommand product);
    }
}
