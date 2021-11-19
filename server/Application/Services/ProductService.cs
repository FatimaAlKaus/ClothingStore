namespace Application.Services
{
    using System;
    using System.Threading.Tasks;
    using Application.Commands.Product.CreateProduct;
    using Application.DTO.Response;
    using Application.Error;
    using Application.Interfaces;
    using Application.ServiceResult;
    using Domain.Models;
    using Domain.Repository;
    using Mapster;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IServiceResult<ProductDto>> CreateProduct(CreateProductCommand product)
        {
            var result = new BaseServiceResult<ProductDto>();

            try
            {
                var model = product.Adapt<Product>();
                model.CreatedDate = model.ModifiedDate = DateTimeOffset.Now;
                result.Data = (await _productRepository.Add(model)).Adapt<ProductDto>();
                result.Success = true;
                return result;
            }
            catch (DbUpdateException)
            {
                result.Error = ApiError.Conflict("Name", nameof(Product), product.Name);

                result.Success = false;
                return result;
            }
            catch (Exception)
            {
                result.Error = ApiError.InternalServerError("Failed to create new product");

                result.Success = false;
                return result;
            }
        }
    }
}
