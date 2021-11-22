namespace Application.Queries.Category
{
    using System.Collections.Generic;
    using Application.DTO.Response;
    using MediatR;

    public record GetCategoryListQuery : IRequest<List<CategoryDto>>;
}
