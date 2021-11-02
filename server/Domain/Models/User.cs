namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Login { get; set; }

        public Cart Cart { get; set; }

        public Collection<Comment> Comments { get; set; }

        public Collection<Order> Orders { get; set; }

        public Collection<Rating> Ratings { get; set; }
    }
}
