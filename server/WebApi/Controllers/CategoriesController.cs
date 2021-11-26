namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Commands.Category.CreateCategory;
    using Application.Commands.Category.DeleteCategory;
    using Application.Commands.Category.UpdateCategory;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Application.Queries.Category;
    using Mapster;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebApi.Request;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMediator _mediator;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            ICategoryService categoryService,
            IMediator mediator)
        {
            _logger = logger;
            _categoryService = categoryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return this.Handle(await _mediator.Send(new GetCategoryListQuery()), successStatusCode: System.Net.HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            return this.Handle(await _mediator.Send(new GetCategoryByIdQuery() { Id = id }), successStatusCode: System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateRequest category)
        {
            return this.Handle(await _mediator.Send(category.Adapt<CreateCategoryCommand>()), successStatusCode: System.Net.HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] CategoryUpdateRequest category)
        {
            return this.Handle(await _mediator.Send(new UpdateCategoryCommand { Id = category.Id, Name = category.Name }), successStatusCode: System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return this.Handle(await _mediator.Send(new DeleteCategoryCommand { Id = id }));
        }
    }
}
