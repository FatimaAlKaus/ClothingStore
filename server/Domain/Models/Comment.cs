namespace Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseEntity
    {
        [Required]
        public Product Product { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Body { get; set; }
    }
}
