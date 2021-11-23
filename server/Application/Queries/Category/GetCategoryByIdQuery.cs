namespace Application.Queries.Category
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class GetCategoryByIdQuery : IRequest<ApiResponse<CategoryDto>>
    {
        public int Id { get; set; }
    }
}
