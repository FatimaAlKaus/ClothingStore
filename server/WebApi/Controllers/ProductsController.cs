namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Commands.Product.CreateProduct;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Mapster;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebApi.Request;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService, IMediator mediator)
        {
            _logger = logger;
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateRequestDto product)
        {
            var result = await _mediator.Send(product.Adapt<CreateProductCommand>());
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.Error.StatusCode, result.Error);
        }
    }
}
