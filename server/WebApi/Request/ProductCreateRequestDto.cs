namespace WebApi.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
