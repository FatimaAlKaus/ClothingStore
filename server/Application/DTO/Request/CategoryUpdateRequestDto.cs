namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryUpdateRequestDto
    {
        [Required]
        public int Id { get; init; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; init; }
    }
}