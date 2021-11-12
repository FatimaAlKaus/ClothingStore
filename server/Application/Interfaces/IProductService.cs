namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;

    public interface IProductService
    {
        Task<ProductDto> GetById(int id);

        Task<List<ProductDto>> GetAll();

        Task<ProductDto> Create(ProductCreateRequestDto product);

        Task<ProductDto> Update(ProductUpdateRequestDto product);

        Task Delete(int id);

        Task<ProductDto> AddCategories(int productId, int[] categoryIds);
    }
}
