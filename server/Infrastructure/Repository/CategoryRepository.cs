namespace Infrastructure.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context)
            : base(context)
        {
        }

        public Category FirstOrDefault(Expression<Func<Category, bool>> predicate)
        {
            return Context.Categories.FirstOrDefault(predicate);
        }
    }
}
