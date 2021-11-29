namespace Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public Order Order { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]

        public bool IsDeleted { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
