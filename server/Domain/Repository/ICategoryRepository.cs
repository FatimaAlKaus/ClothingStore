namespace Domain.Repository
{
    using System;
    using System.Linq.Expressions;
    using Domain.Models;

    public interface ICategoryRepository : IRepository<Category>
    {
        Category FirstOrDefault(Expression<Func<Category, bool>> predicate);
    }
}
