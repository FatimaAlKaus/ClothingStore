namespace WebApi.Request
{
    using System.ComponentModel.DataAnnotations;

    public class ProductUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(100, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
