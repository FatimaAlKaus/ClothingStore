using Domain.Models;
using System.Collections.Generic;

namespace WebAPI.MockFactory.Tests.Data
{
    public static class TestProducts
    {
        public static Product ProductA => new() { Name = "ProductA" };
        public static Product ProductB => new() { Name = "ProductB" };
        public static Product ProductC => new() { Name = "ProductC" };
        public static List<Product> AllProducts => new() { ProductA, ProductB, ProductC };
    }
}
