namespace Application.Queries.Category
{
    using System.Collections.Generic;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public record GetCategoryListQuery : IRequest<ApiResponse<List<CategoryDto>>>;
}
