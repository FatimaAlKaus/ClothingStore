namespace Application.Queries
{
    using System.Collections.Generic;
    using Application.DTO.Response;
    using MediatR;

    public record GetCategoryListQuery : IRequest<List<CategoryDto>>;
}
