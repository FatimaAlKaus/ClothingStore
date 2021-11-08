namespace Application.ViewModels
{
    using System;
    using Domain.Models;

    public class CategoryDto
    {
        public CategoryDto(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.CreatedDate = category.CreatedDate;
            this.ModifiedDate = category.ModifiedDate;
        }

        public int Id { get; }

        public string Name { get; }

        public DateTime CreatedDate { get; }

        public DateTime ModifiedDate { get; }
    }
}
