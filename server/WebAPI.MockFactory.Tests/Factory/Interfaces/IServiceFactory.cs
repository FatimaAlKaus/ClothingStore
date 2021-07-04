using Application.Interfaces;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    public interface IServiceFactory
    {
        IProductService CreateProductService();
    }
}