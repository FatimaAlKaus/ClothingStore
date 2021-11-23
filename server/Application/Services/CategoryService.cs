namespace Application.Services
{
    using System;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Commands.Category.CreateCategory;
    using Application.Commands.Category.UpdateCategory;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Domain.Models;
    using Domain.Repository;
    using Mapster;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<CategoryDto>> Create(CreateCategoryCommand category)
        {
            var result = new ApiResponse<CategoryDto>();

            try
            {
                var model = category.Adapt<Category>();
                model.CreatedDate = model.ModifiedDate = DateTimeOffset.Now;
                result.Data = (await _repository.Add(model)).Adapt<CategoryDto>();
            }
            catch (DbUpdateException)
            {
                result.Error = ApiError.Conflict("Name", nameof(Category), category.Name);
                result.Success = false;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to create new category");

                result.Success = false;
            }

            return result;
        }

        public async Task<ApiResponse<CategoryDto>> Update(UpdateCategoryCommand category)
        {
            var result = new ApiResponse<CategoryDto>();
            try
            {
                var model = await _repository.GetById(category.Id);

                if (model is null)
                {
                    result.Error = ApiError.NotFound(nameof(Category), category.Id);
                    result.Success = false;
                    return result;
                }

                model.Name = category.Name;
                model.ModifiedDate = DateTimeOffset.Now;

                await _repository.Update();
                result.Data = model.Adapt<CategoryDto>();
            }
            catch (DbUpdateException)
            {
                result.Error = ApiError.Conflict("Name", nameof(Category), category.Name);

                result.Success = false;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to update category");

                result.Success = false;
            }

            return result;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            var result = new ApiResponse();
            try
            {
                var model = await _repository.GetById(id);
                if (model is null)
                {
                    result.Error = ApiError.NotFound(nameof(Category), id);
                    result.Success = false;
                    return result;
                }

                await _repository.Remove(model);
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to delete category");

                result.Success = false;
            }

            return result;
        }
    }
}
