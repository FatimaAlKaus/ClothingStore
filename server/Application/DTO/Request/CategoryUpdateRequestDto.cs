namespace Application.DTO.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class CategoryUpdateRequestDto : IDtoMapper<Category>
    {
        [Required]
        public int Id { get; init; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; init; }

        public Category ToModel()
        {
            return new Category() { Id = this.Id, ModifiedDate = DateTime.Now, Name = this.Name };
        }
    }
}