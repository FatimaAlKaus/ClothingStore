namespace Domain.Repository
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IRepository<T>
        where T : BaseEntity
    {
        T GetById(int id);

        T Add(T entity);

        T Update(T entity);

        void Remove(T entity);

        IEnumerable<T> GetAll();
    }
}
