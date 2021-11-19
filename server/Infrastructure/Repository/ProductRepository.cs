namespace Infrastructure.Repository
{
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    public class ProductRepository : BaseAsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
