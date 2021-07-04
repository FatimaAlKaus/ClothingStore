using Infrastructure.EF;
using System;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    public interface IRepositoryContextFactory : IDisposable
    {
        DatabaseContext CreateDatabaseContext();
    }
}