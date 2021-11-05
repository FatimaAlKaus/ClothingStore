namespace Infrastructure.Repository
{
    using System.Collections.Generic;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class BaseRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }

        protected DatabaseContext Context => _context;

        public T Add(T entity)
        {
            var entry = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            var entry = _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
