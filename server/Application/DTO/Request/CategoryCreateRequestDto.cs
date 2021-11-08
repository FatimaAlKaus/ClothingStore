namespace Application.DTO.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class CategoryCreateRequestDto : IDtoMapper<Category>
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]

        public string Name { get; init; }

        public Category ToModel()
        {
            var createdDate = DateTime.Now;
            return new Category()
            {
                Name = this.Name,
                CreatedDate = createdDate,
                ModifiedDate = createdDate,
            };
        }
    }
}
