namespace WebApi.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
