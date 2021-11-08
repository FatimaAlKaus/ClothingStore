namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Repository;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryDto Add(CategoryCreateRequestDto category)
        {
            return new CategoryDto(_repository.Add(category.ToModel()));
        }

        public List<CategoryDto> GetAll()
        {
            return _repository.GetAll().Select(x => new CategoryDto(x)).ToList();
        }

        public CategoryDto GetById(int id)
        {
            var category = _repository.GetById(id);
            if (category is null)
            {
                return null;
            }

            return new CategoryDto(category);
        }

        public CategoryDto Update(CategoryUpdateRequestDto category)
        {
            return new CategoryDto(_repository.Update(category.ToModel()));
        }
    }
}
