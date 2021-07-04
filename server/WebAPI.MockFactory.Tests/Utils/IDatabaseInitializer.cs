using Infrastructure.EF;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.MockFactory.Tests.Utils
{
    public interface IDatabaseInitializer
    {
        void InitializeDatabase(Action<ILogger<DatabaseInitializer>, DatabaseContext> initializeAction);
    }
}