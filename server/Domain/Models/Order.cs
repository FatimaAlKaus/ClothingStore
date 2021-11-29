namespace Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseEntity
    {
        [Required]

        public ICollection<Product> Products { get; set; }

        [Required]

        public User User { get; set; }
    }
}
