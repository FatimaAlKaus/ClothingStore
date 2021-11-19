namespace Application.Commands.Category.UpdateCategory
{
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class UpdateCategoryCommand : IRequest<IServiceResult<CategoryDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
