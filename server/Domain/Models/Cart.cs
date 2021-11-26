namespace Domain.Models
{
    using System.Collections.ObjectModel;

    public class Cart : BaseEntity
    {
        public User User { get; set; }

        public Collection<Product> Products { get; set; }
    }
}
