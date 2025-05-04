using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/v1/supplier")]
    public class SupplierController
    {
        private readonly SupplierService _service;

        public SupplierController(SupplierService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SupplierReadDTO> Create([FromBody] SupplierCreateDTO createDto)
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
        public ActionResult<IEnumerable<SupplierReadDTO>> GetAll()
        {
            return _service.FindAll();
        }

        [HttpGet("id=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SupplierReadDTO> GetById(int id)
        {
            return _service.FindById(id);
        }

        [HttpPatch("update:id={id}&supplier=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SupplierReadDTO> UpdateQuantities(int id, SupplierCreateDTO supplier)
        {
            return _service.Update(id, supplier); ;
        }
    }
}
