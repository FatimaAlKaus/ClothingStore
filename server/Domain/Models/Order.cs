namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseEntity
    {
        [Required]

        public Collection<Product> Products { get; set; }

        [Required]

        public User User { get; set; }
    }
}
