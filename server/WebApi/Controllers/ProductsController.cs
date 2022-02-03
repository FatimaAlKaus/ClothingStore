namespace WebApi.Controllers
{
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using Application.Commands.Product.CreateProduct;
    using Application.Commands.Product.DeleteProduct;
    using Application.Commands.Product.UpdateProduct;
    using Application.DTO.Response;
    using Application.Queries.Product;
    using Application.QueryParameters;
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
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductDto>>> GetAll([FromQuery] ProductsQueryParameters parameters)
        {
            return this.Handle(await _mediator.Send(new GetProductListQuery() { Parameters = parameters }), successStatusCode: System.Net.HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            return this.Handle(await _mediator.Send(new GetProductByIdQuery() { Id = id }), System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromForm] ProductCreateRequest product)
        {
            return this.Handle(
                await _mediator.Send(new CreateProductCommand()
                {
                    Name = product.Name,
                    Categories = product.Categories,
                    Price = product.Price,
                    File = product.File.OpenReadStream(),
                    FileFormat = product.File.FileName.Split('.').Last(),
                    Images = product.Images
                    .Select(x => new Image() { Photo = x.OpenReadStream(), FileFormat = x.FileName.Split('.').Last() })
                    .ToArray(),
                }), System.Net.HttpStatusCode.Created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return this.Handle(await _mediator.Send(new DeleteProductCommand() { Id = id }));
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductUpdateRequest product)
        {
            return this.Handle(await _mediator.Send(product.Adapt<UpdateProductCommand>()), System.Net.HttpStatusCode.OK);
        }
    }
}
