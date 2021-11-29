namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Commands.Category.CreateCategory;
    using Application.Commands.Category.UpdateCategory;
    using Application.DTO.Response;

    public interface ICategoryService
    {
        Task<ApiResponse<CategoryDto>> Create(CreateCategoryCommand category);

        Task<ApiResponse<CategoryDto>> Update(UpdateCategoryCommand category);

        Task<ApiResponse> Delete(int id);
    }
}
