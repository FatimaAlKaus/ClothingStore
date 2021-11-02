namespace Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public User User { get; set; }
    }
}
