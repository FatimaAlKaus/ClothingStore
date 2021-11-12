namespace Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : BaseAsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await Context.Products.Include(x => x.Categories).ToListAsync();
        }

        public override async Task<Product> Update(Product entity)
        {
            Context.Entry(await Context.Products.FirstOrDefaultAsync(x => x.Id == entity.Id)).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return await Context.Products
                .Include(x => x.Categories)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
    }
}
