namespace Infrastructure.Repository
{
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
