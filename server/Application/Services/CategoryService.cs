namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
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

        public async Task<CategoryDto> Create(CategoryCreateRequestDto category)
        {
            return (await _repository.Add(category.Adapt<Category>()))
                .Adapt<CategoryDto>();
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var collection = await _repository.GetAll();
            return collection.Select(x => x.Adapt<CategoryDto>()).ToList();
        }

        public async Task<CategoryDto> GetById(int id)
        {
            return (await _repository.GetById(id)).Adapt<CategoryDto>();
        }

        public async Task<CategoryDto> Update(CategoryUpdateRequestDto category)
        {
            return (await _repository.Update(category.Adapt<Category>())).Adapt<CategoryDto>();
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(await _repository.GetById(id));
        }
    }
}
