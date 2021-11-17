namespace Application.UseCases.Category.Commands.CreateCategory
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.DTO.Response;
    using Domain.Repository;
    using Mapster;
    using MediatR;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createdDate = DateTimeOffset.Now;
            var category = new Domain.Models.Category
            {
                CreatedDate = createdDate,
                ModifiedDate = createdDate,
                Name = request.Name,
            };
            return (await _categoryRepository.Add(category)).Adapt<CategoryDto>();
        }
    }
}
