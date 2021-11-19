namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Commands.Category.CreateCategory;
    using Application.Commands.Category.UpdateCategory;
    using Application.DTO.Response;
    using Application.Error;
    using Application.Interfaces;
    using Application.ServiceResult;
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

        public async Task<BaseServiceResult<CategoryDto>> Create(CreateCategoryCommand category)
        {
            var result = new BaseServiceResult<CategoryDto>();

            try
            {
                var model = category.Adapt<Category>();
                model.CreatedDate = model.ModifiedDate = DateTimeOffset.Now;
                result.Data = (await _repository.Add(model)).Adapt<CategoryDto>();
                result.Success = true;
                return result;
            }
            catch (DbUpdateException)
            {
                result.Error = ApiError.Conflict("Name", nameof(Category), category.Name);

                result.Success = false;
                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to create new category");

                result.Success = false;
                return result;
            }
        }

        public async Task<BaseServiceResult<List<CategoryDto>>> GetAll()
        {
            var result = new BaseServiceResult<List<CategoryDto>>();

            try
            {
                result.Data = (await _repository.GetAll()).Select(x => x.Adapt<CategoryDto>()).ToList();
                result.Success = true;

                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to get list of categories");
                result.Success = false;
                return result;
            }
        }

        public async Task<BaseServiceResult<CategoryDto>> GetById(int id)
        {
            var result = new BaseServiceResult<CategoryDto>();

            try
            {
                var dto = (await _repository.GetById(id)).Adapt<CategoryDto>();
                if (dto is null)
                {
                    result.Success = false;
                    result.Error = ApiError.NotFound(nameof(Category), id);
                    return result;
                }

                result.Data = dto;
                result.Success = true;

                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to get category by id");
                result.Success = false;
                return result;
            }
        }

        public async Task<BaseServiceResult<CategoryDto>> Update(UpdateCategoryCommand category)
        {
            var result = new BaseServiceResult<CategoryDto>();
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
                result.Success = true;
                return result;
            }
            catch (DbUpdateException)
            {
                result.Error = ApiError.Conflict("Name", nameof(Category), category.Name);

                result.Success = false;
                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to update category");

                result.Success = false;
                return result;
            }
        }

        public async Task<BaseServiceResult> Delete(int id)
        {
            var result = new BaseServiceResult();
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
                result.Success = true;
                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to delete category");

                result.Success = false;
                return result;
            }
        }
    }
}
