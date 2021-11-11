namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Domain.Models;
    using Domain.Repository;
    using Mapster;

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetProducts().Select(x => x.Adapt<ProductDto>()).ToList();
        }

        public ProductDto InsetProduct(ProductCreateRequestDto product)
        {
            return _productRepository.InsertProduct(product.Adapt<Product>()).Adapt<ProductDto>();
        }
    }
}
