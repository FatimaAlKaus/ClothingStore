namespace Application.Commands.Category.CreateCategory
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class CreateCategoryCommand : IRequest<ApiResponse<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
