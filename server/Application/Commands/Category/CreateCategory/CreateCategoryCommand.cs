namespace Application.Commands.Category.CreateCategory
{
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class CreateCategoryCommand : IRequest<IServiceResult<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
