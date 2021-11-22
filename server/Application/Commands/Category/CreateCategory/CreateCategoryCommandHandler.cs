namespace Application.Commands.Category.CreateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.Create(request);
        }
    }
}
