using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductReadDTO> Create([FromBody] ProductCreateDTO createDto)
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
        public ActionResult<IEnumerable<ProductReadDTO>> GetAll()
        {
            return _service.FindAll();
        }

        [HttpGet("id=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductReadDTO> GetById(int id)
        {
            return _service.FindById(id);
        }

        [HttpPatch("update:id={id}&product=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductReadDTO> UpdateQuantities(int id, ProductCreateDTO product)
        {
            return _service.Update(id, product); ;
        }
    }
}
