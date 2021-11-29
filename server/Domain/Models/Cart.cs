namespace Domain.Models
{
    using System.Collections.Generic;

    public class Cart : BaseEntity
    {
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
