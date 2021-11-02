namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public Order Order { get; set; }

        [Required]
        public Collection<Category> Categories { get; set; }

        public Collection<Comment> Comments { get; set; }

        public Collection<Rating> Ratings { get; set; }
    }
}
