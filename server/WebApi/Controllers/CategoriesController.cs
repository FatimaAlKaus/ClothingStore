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
            return await _mediator.Send(new GetCategoryListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.Error.StatusCode, result.Error);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateRequestDto category)
        {
            var result = await _mediator.Send(category.Adapt<CreateCategoryCommand>());
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.Error.StatusCode, result.Error);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] CategoryUpdateRequestDto category)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand { Id = category.Id, Name = category.Name });
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error);
            }
        }
    }
}
