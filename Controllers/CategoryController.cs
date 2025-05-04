using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoryReadDTO> Create([FromBody] CategoryCreateDTO createDto)
        {
            return _service.Create(createDto);
        }
        [HttpDelete("delete=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            return _service.DeleteById(id);
        }
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CategoryReadDTO>> GetAll()
        {
            return _service.FindAll();
        }

        [HttpGet("id=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoryReadDTO> GetById(int id)
        {
            return _service.FindById(id);
        }

        [HttpPatch("update:id={id}&category=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoryReadDTO> UpdateQuantities(int id, CategoryCreateDTO category)
        {
            return _service.Update(id, category); ;
        }
    }
}
