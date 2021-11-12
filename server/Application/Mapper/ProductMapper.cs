namespace Application.Mapper
{
    using System.Linq;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Domain.Models;
    using Mapster;

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
                CreatedDate = product.CreatedDate,
                ModifiedDate = product.ModifiedDate,
            };
        }

        public static Product AdaptToMapDto(this ProductCreateRequestDto product)
        {
            return product == null ? null : new Product()
            {
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}
