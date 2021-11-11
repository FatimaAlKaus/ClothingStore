using System;
using System.Collections.Generic;
using Domain.Models;

namespace Application.DTO.Response
{
    public class CategoryDto
    {
        public string Name { get; init; }
        public int Id { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public DateTimeOffset ModifiedDate { get; init; }
    }
}