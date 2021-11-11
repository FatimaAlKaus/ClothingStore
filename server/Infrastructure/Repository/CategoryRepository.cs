namespace Infrastructure.Repository
{
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    public class CategoryRepository : BaseAsyncRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
