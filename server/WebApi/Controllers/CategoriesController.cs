namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
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
        public ActionResult<List<CategoryDto>> GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get(int id)
        {
            var categoryDto = _categoryService.GetById(id);
            if (categoryDto is null)
            {
                return NotFound("Category with this Id was not found");
            }

            return Ok(categoryDto);
        }

        [HttpPost]
        public ActionResult<CategoryDto> Create([FromBody] CategoryCreateRequestDto category)
        {
            if (_categoryService.GetByName(category.Name) is null)
            {
                var categoryDto = _categoryService.Add(category);
                string uri = Request.Path.Value + "/" + categoryDto.Id;
                return Created(uri, categoryDto);
            }

            return Conflict("A category with the same name already exists");
        }

        [HttpPut]
        public ActionResult<CategoryDto> Update([FromBody] CategoryUpdateRequestDto category)
        {
            if (_categoryService.GetById(category.Id) is null)
            {
                return NotFound("Category with this Id was not found");
            }

            if (_categoryService.GetByName(category.Name) is not null)
            {
                return Conflict("A category with the same name already exists");
            }

            return Ok(_categoryService.Update(category));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_categoryService.GetById(id) is null)
            {
                return NotFound("Category with this Id was not found");
            }

            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
