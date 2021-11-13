namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Application.ServiceResult;
    using Domain.Models;
    using Domain.Repository;
    using Mapster;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseServiceResult<CategoryDto>> Create(CategoryCreateRequestDto category)
        {
            CategoryDto dto = null;
            var result = new BaseServiceResult<CategoryDto>();
            try
            {
                dto = (await _repository.Add(category.Adapt<Category>())).Adapt<CategoryDto>();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Success = false;
                result.Data = null;
                return result;
            }

            result.Data = dto;
            result.Success = true;
            return result;
        }

        public async Task<BaseServiceResult<List<CategoryDto>>> GetAll()
        {
            List<CategoryDto> categories = null;
            var result = new BaseServiceResult<List<CategoryDto>>();
            try
            {
                categories = (await _repository.GetAll()).Select(x => x.Adapt<CategoryDto>()).ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Success = false;
                result.Data = null;
                return result;
            }

            result.Data = categories;
            result.Success = true;
            return result;
        }

        public async Task<BaseServiceResult<CategoryDto>> GetById(int id)
        {
            CategoryDto category = null;
            var result = new BaseServiceResult<CategoryDto>();
            try
            {
                category = (await _repository.GetById(id)).Adapt<CategoryDto>();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Success = false;
                result.Data = null;
                return result;
            }

            result.Data = category;
            result.Success = true;
            return result;
        }

        public async Task<BaseServiceResult<CategoryDto>> Update(CategoryUpdateRequestDto category)
        {
            CategoryDto dto = null;
            var result = new BaseServiceResult<CategoryDto>();
            try
            {
                dto = (await _repository.Update(category.Adapt<Category>())).Adapt<CategoryDto>();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Success = false;
                result.Data = null;
                return result;
            }

            result.Data = dto;
            result.Success = true;
            return result;
        }

        public async Task<BaseServiceResult> Delete(int id)
        {
            var result = new BaseServiceResult();
            try
            {
                await _repository.Remove(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Success = false;
                return result;
            }

            result.Success = true;
            return result;
        }
    }
}
