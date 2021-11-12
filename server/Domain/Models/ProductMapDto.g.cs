using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Models
{
    public partial class ProductMapDto
    {
        public string Name { get; set; }
        public Order Order { get; set; }
        public ICollection<Category> Categories { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}