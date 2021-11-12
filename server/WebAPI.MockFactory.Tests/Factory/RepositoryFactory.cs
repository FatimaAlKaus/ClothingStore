namespace WebAPI.MockFactory.Tests.Factory
{
    using Domain.Repository;
    using Infrastructure.Repository;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;

    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IRepositoryContextFactory _repositoryContextFactory;

        public RepositoryFactory(IRepositoryContextFactory repositoryContextFactory)
        {
            _repositoryContextFactory = repositoryContextFactory;
        }

        public ICategoryRepository CreateCategoryRepository()
        {
            return new CategoryRepository(_repositoryContextFactory.CreateDatabaseContext());
        }

        public IProductRepository CreateProductRepository()
        {
            return new ProductRepository(_repositoryContextFactory.CreateDatabaseContext());
        }
    }
}
