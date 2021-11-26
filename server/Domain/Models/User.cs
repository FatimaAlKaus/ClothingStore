namespace Domain.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string SecondName { get; set; }

        [MinLength(2)]
        public string Patronymic { get; set; }

        [Required]
        [MinLength(2)]
        public string Login { get; set; }

        public Cart Cart { get; set; }

        public Collection<Comment> Comments { get; set; }

        public Collection<Order> Orders { get; set; }

        public Collection<Rating> Ratings { get; set; }
    }
}
