namespace Application.Commands.Category.UpdateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Application.Interfaces;
    using MediatR;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IServiceResult<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public async Task<IServiceResult<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.Update(request);
        }
    }
}
