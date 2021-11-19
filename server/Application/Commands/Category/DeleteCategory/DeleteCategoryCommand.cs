namespace Application.Commands.Category.DeleteCategory
{
    using Application.Interfaces;
    using MediatR;

    public class DeleteCategoryCommand : IRequest<IServiceResult>
    {
        public int Id { get; set; }
    }
}
