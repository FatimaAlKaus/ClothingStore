namespace Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class BaseAsyncRepository<T> : IAsyncRepository<T>
        where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public BaseAsyncRepository(DatabaseContext context)
        {
            _context = context;
        }

        protected DatabaseContext Context => _context;

        public virtual async Task<T> Add(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task Remove(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id)).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
    }
}
