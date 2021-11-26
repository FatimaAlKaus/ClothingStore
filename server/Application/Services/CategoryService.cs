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
            try
            {
                var model = category.Adapt<Category>();
                model.CreatedDate = model.ModifiedDate = DateTimeOffset.Now;
                return (await _repository.Add(model)).Adapt<CategoryDto>();
            }
            catch (DbUpdateException)
            {
                return ApiError.Conflict("Name", nameof(Category), category.Name);
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Failed to create new category");
            }
        }

        public async Task<ApiResponse<CategoryDto>> Update(UpdateCategoryCommand category)
        {
            try
            {
                var model = await _repository.GetById(category.Id);

                if (model is null)
                {
                    return ApiError.NotFound(nameof(Category), category.Id);
                }

                model.Name = category.Name;
                model.ModifiedDate = DateTimeOffset.Now;

                await _repository.Update();
                return model.Adapt<CategoryDto>();
            }
            catch (DbUpdateException)
            {
                return ApiError.Conflict("Name", nameof(Category), category.Name);
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Failed to update category");
            }
        }

        public async Task<ApiResponse> Delete(int id)
        {
            try
            {
                var model = await _repository.GetById(id);
                if (model is null)
                {
                    return ApiError.NotFound(nameof(Category), id);
                }

                await _repository.Remove(model);
                return new ApiResponse();
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Failed to delete category");
            }
        }
    }
}
