namespace Application.DTO.Response
{
    using System;
    using System.Collections.Generic;

    public class ProductDto
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public string ProductImage { get; init; }

        public List<CategoryDto> Categories { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

        public DateTimeOffset ModifiedDate { get; init; }
    }
}
