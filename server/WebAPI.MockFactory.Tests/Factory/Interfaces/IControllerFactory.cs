using WebApi.Controllers;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    public interface IControllerFactory
    {
        ProductsController CreateProductsController();
    }
}