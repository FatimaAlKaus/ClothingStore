namespace Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Color : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Hex { get; set; }
    }
}
