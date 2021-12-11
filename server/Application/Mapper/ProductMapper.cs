namespace Application.Mapper
{
    using System.Linq;
    using Application.Commands.Product.CreateProduct;
    using Application.DTO.Response;
    using Domain.Models;
    using Mapster;
    using Microsoft.Extensions.Configuration;

    public static class ProductMapper
    {
        public static ProductDto AdaptToMapDto(this Product product)
        {
            return product == null ? null : new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Categories = product.Categories.Select(x => x.Adapt<CategoryDto>()).ToList(),
                Price = product.Price,
                Description = product.Description ?? string.Empty,
                CreatedDate = product.CreatedDate,
                ModifiedDate = product.ModifiedDate,
            };
        }

        public static Product AdaptToMapDto(this CreateProductCommand product)
        {
            return product == null ? null : new Product()
            {
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}
