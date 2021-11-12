namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var productDto = await _productService.GetById(id);
            if (productDto is null)
            {
                return NotFound("Product with this Id was not found");
            }

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateRequestDto product)
        {
            var productDto = await _productService.Create(product);
            string uri = Request.Path.Value + "/" + productDto.Id;
            return Created(uri, productDto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductUpdateRequestDto product)
        {
            if (await _productService.GetById(product.Id) is null)
            {
                return NotFound("Product with this Id was not found");
            }

            return Ok(await _productService.Update(product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _productService.GetById(id) is null)
            {
                return NotFound("Product with this Id was not found");
            }

            await _productService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDto>> AddCategories(int id, int[] categoryIds)
        {
            if (await _productService.GetById(id) is null)
            {
                return NotFound("Product with this Id was not found");
            }

            return Ok(await _productService.AddCategories(id, categoryIds));
        }
    }
}
