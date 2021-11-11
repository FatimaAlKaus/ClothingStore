namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryCreateRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]

        public string Name { get; init; }
    }
}
