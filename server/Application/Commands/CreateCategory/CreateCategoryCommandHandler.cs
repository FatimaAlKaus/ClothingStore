namespace Application.Commands.CreateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IServiceResult<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IServiceResult<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.Create(request);
        }
    }
}
