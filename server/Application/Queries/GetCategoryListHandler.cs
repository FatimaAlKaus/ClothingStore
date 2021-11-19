namespace Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return (await _categoryRepository.GetAll()).Select(x => x.Adapt<CategoryDto>()).ToList();
        }
    }
}
