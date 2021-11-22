namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Commands.Product.CreateProduct;
    using Application.DTO.Response;

    public interface IProductService
    {
        Task<ApiResponse<ProductDto>> CreateProduct(CreateProductCommand product);
    }
}
