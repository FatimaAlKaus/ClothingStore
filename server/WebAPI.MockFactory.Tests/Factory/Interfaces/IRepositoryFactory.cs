using Domain.Repository;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    public interface IRepositoryFactory
    {
        IProductRepository CreateProductRepository();
    }
}