namespace Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
