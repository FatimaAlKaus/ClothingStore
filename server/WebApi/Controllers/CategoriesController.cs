namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            this._logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto is null)
            {
                return NotFound("Category with this Id was not found");
            }

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateRequestDto category)
        {
            if (!(await _categoryService.GetAll()).Any(x => x.Name == category.Name))
            {
                var categoryDto = await _categoryService.Create(category);
                string uri = Request.Path.Value + "/" + categoryDto.Id;
                return Created(uri, categoryDto);
            }

            return Conflict("A category with the same name already exists");
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] CategoryUpdateRequestDto category)
        {
            if (await _categoryService.GetById(category.Id) is null)
            {
                return NotFound("Category with this Id was not found");
            }

            if ((await _categoryService.GetAll()).Any(x => x.Name == category.Name))
            {
                return Conflict("A category with the same name already exists");
            }

            return Ok(await _categoryService.Update(category));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _categoryService.GetById(id) is null)
            {
                return NotFound("Category with this Id was not found");
            }

            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}
