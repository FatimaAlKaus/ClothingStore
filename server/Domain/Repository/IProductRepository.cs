namespace Domain.Repository
{
    using System.Linq;
    using Domain.Models;

    public interface IProductRepository : IAsyncRepository<Product>
    {
        IQueryable<Product> GetAsQueryable();
    }
}
