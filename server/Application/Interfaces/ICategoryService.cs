namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface ICategoryService
    {
        CategoryDto GetById(int id);

        List<CategoryDto> GetAll();

        CategoryDto Add(CategoryCreateRequestDto category);

        CategoryDto Update(CategoryUpdateRequestDto category);

        CategoryDto GetByName(string name);

        void Delete(int id);
    }
}
