namespace Application.UseCases.Category.Queries
{
    using System.Collections.Generic;
    using Application.DTO.Response;
    using MediatR;

    public record GetCategoryListQuery : IRequest<List<CategoryDto>>;
}
