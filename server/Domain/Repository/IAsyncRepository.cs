namespace Domain.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IAsyncRepository<T>
             where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<T> Add(T entity);

        Task Update();

        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
