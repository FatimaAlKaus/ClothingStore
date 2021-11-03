namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public Order Order { get; set; }

        [Required]
        public Collection<Category> Categories { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]

        public bool IsDeleted { get; set; }

        public Collection<Comment> Comments { get; set; }

        public Collection<Rating> Ratings { get; set; }
    }
}
