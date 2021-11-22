namespace Application.Commands.Category.UpdateCategory
{
    using Application.ApiResponse;
    using Application.DTO.Response;
    using MediatR;

    public class UpdateCategoryCommand : IRequest<ApiResponse<CategoryDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
