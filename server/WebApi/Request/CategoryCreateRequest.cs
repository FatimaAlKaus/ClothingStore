namespace WebApi.Request
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(50)]

        public string Name { get; init; }
    }
}
