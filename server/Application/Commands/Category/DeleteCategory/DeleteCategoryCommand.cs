namespace Application.Commands.Category.DeleteCategory
{
    using Application.ApiResponse;
    using MediatR;

    public class DeleteCategoryCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
