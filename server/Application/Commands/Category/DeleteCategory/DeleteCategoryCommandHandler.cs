namespace Application.Commands.Category.DeleteCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using MediatR;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IServiceResult>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public int Id { get; set; }

        public async Task<IServiceResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.Delete(request.Id);
        }
    }
}
