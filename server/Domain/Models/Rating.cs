namespace Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating : BaseEntity
    {
        [Required]
        public Product Product { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [Range(0, 5)]
        public double Grade { get; set; }
    }
}
