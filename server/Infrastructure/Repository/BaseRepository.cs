namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            entity.CreatedDate = entity.ModifiedDate = DateTime.Now;
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
            return _context.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
