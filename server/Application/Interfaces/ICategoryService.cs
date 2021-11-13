namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.ServiceResult;

    public interface ICategoryService
    {
        Task<BaseServiceResult<CategoryDto>> GetById(int id);

        Task<BaseServiceResult<List<CategoryDto>>> GetAll();

        Task<BaseServiceResult<CategoryDto>> Create(CategoryCreateRequestDto category);

        Task<BaseServiceResult<CategoryDto>> Update(CategoryUpdateRequestDto category);

        Task<BaseServiceResult> Delete(int id);
    }
}
