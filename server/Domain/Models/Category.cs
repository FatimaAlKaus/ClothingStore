namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public Collection<Product> Products { get; set; }
    }
}
