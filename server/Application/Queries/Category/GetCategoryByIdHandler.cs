namespace Application.Queries.Category
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public record GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _categoryRepository.GetById(request.Id);
            if (model is null)
            {
                return ApiError.NotFound(nameof(model), request.Id);
            }

            return model.Adapt<CategoryDto>();
        }
    }
}
