namespace Application.UseCases.Category.Commands.CreateCategory
{
    using Application.DTO.Response;
    using MediatR;

    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }
    }
}
