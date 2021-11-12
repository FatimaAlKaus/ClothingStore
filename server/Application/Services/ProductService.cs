namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
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

        public async Task<ProductDto> Create(ProductCreateRequestDto product)
        {
            var model = product.Adapt<Product>();
            var categories = (await _categoryRepository.GetAll()).Where(x => product.Categories.Contains(x.Id));
            model.Categories = categories.ToList();
            return (await _productRepository.Add(model)).Adapt<ProductDto>();
        }

        public async Task Delete(int id)
        {
            await _productRepository.Remove(await _productRepository.GetById(id));
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return (await _productRepository.GetAll()).Select(x => x.Adapt<ProductDto>()).ToList();
        }

        public async Task<ProductDto> GetById(int id)
        {
            return (await _productRepository.GetById(id)).Adapt<ProductDto>();
        }

        public async Task<ProductDto> Update(ProductUpdateRequestDto product)
        {
            return (await _productRepository.Update(product.Adapt<Product>())).Adapt<ProductDto>();
        }

        public async Task<ProductDto> AddCategories(int productId, int[] categoryIds)
        {
            var product = await _productRepository.GetById(productId);
            var categories = (await _categoryRepository.GetAll()).Where(x => categoryIds.Contains(x.Id)).ToList();
            product.Categories ??= new List<Category>();
            categories.ForEach(x => product.Categories.Add(x));
            return (await _productRepository.Update(product)).Adapt<ProductDto>();
        }
    }
}
