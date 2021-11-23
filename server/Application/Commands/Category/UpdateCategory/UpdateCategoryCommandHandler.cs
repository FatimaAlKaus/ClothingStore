namespace Application.Commands.Category.UpdateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.Update(request);
        }
    }
}
