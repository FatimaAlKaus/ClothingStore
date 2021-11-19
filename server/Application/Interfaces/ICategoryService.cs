namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Commands.Category.CreateCategory;
    using Application.Commands.Category.UpdateCategory;
    using Application.DTO.Response;
    using Application.ServiceResult;

    public interface ICategoryService
    {
        Task<BaseServiceResult<CategoryDto>> GetById(int id);

        Task<BaseServiceResult<List<CategoryDto>>> GetAll();

        Task<BaseServiceResult<CategoryDto>> Create(CreateCategoryCommand category);

        Task<BaseServiceResult<CategoryDto>> Update(UpdateCategoryCommand category);

        Task<BaseServiceResult> Delete(int id);
    }
}
