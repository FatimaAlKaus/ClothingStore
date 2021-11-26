﻿namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.ApiResponse;
    using Application.Commands.Product.CreateProduct;
    using Application.Commands.Product.UpdateProduct;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Domain.Models;
    using Domain.Repository;
    using Mapster;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<ProductDto>> Create(CreateProductCommand product)
        {
            try
            {
                var model = product.Adapt<Product>();
                model.CreatedDate = model.ModifiedDate = DateTimeOffset.Now;
                model.Categories = new List<Category>();
                foreach (var index in product.Categories)
                {
                    var category = await _categoryRepository.GetById(index);
                    if (category is null)
                    {
                        return ApiError.NotFound(nameof(Category), index);
                    }

                    model.Categories.Add(category);
                }

                return (await _productRepository.Add(model)).Adapt<ProductDto>();
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Failed to create new product");
            }
        }

        public async Task<ApiResponse> Delete(int id)
        {
            try
            {
                var model = await _productRepository.GetById(id);
                if (model is null)
                {
                    return ApiError.NotFound(nameof(Product), id);
                }

                await _productRepository.Remove(model);
                return new ApiResponse() { Success = true };
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Failed to delete product");
            }
        }

        public async Task<ApiResponse<ProductDto>> Update(UpdateProductCommand product)
        {
            try
            {
                var model = await _productRepository.GetById(product.Id);
                if (model is null)
                {
                    return ApiError.NotFound(nameof(Product), product.Id);
                }

                model.Name = product.Name;
                model.Price = product.Price;
                model.ModifiedDate = DateTimeOffset.Now;

                await _productRepository.Update();
                return model.Adapt<ProductDto>();
            }
            catch (Exception)
            {
                return ApiError.InternalServerError("Faield to update product");
            }
        }
    }
}
