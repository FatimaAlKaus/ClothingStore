namespace Application.DTO.Response
{
    using System;

    public class CategoryDto
    {
        public string Name { get; init; }

        public int Id { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

        public DateTimeOffset ModifiedDate { get; init; }
    }
}
