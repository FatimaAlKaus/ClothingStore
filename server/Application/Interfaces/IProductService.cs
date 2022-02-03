namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Commands.Product.CreateProduct;
    using Application.Commands.Product.UpdateProduct;
    using Application.DTO.Response;

    public interface IProductService
    {
        Task<ApiResponse<ProductDto>> Create(CreateProductCommand product);

        Task<ApiResponse<ProductDto>> Update(UpdateProductCommand product);

        Task<ApiResponse> UpdateRange(List<UpdateProductCommand> list);

        Task<ApiResponse> Delete(int id);
    }
}
