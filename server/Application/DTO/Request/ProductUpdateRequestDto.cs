namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductUpdateRequestDto
    {
        [Required]
        public int Id { get; init; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; init; }

        [Required]
        [Range(20, int.MaxValue)]
        public int Price { get; init; }
    }
}
