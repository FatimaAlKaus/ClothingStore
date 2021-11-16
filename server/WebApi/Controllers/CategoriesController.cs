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
            var result = await _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateRequestDto category)
        {
            var result = await _categoryService.Create(category);
            if (result.Success)
            {
                return StatusCode(201, result.Data);
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] CategoryUpdateRequestDto category)
        {
            var result = await _categoryService.Update(category);
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
            var result = await _categoryService.Delete(id);
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
