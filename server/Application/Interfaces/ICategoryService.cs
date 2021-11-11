namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;

    public interface ICategoryService
    {
        Task<CategoryDto> GetById(int id);

        Task<List<CategoryDto>> GetAll();

        Task<CategoryDto> Create(CategoryCreateRequestDto category);

        Task<CategoryDto> Update(CategoryUpdateRequestDto category);

        Task Delete(int id);
    }
}
