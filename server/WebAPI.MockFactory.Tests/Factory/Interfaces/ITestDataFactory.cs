using System;
using WebAPI.MockFactory.Tests.Factory.Interfaces;
using WebAPI.MockFactory.Tests.Utils;

namespace WebAPI.MockFactory.Tests.Factory
{
    public interface ITestDataFactory : IDisposable
    {
        IControllerFactory CreateControllerFactory();
        IDatabaseInitializer CreateDatabaseInitializer();
    }
}