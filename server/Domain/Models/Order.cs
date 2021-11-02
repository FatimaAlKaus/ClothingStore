namespace Domain.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        [Required]

        public Collection<Product> Products { get; set; }

        [Required]

        public User User { get; set; }

        [Required]

        public DateTime OrderDate { get; set; }
    }
}
