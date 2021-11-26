namespace Domain.Models
{
    using System.Collections.Generic;
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

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
