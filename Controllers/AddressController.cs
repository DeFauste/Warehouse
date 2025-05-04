using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AddressReadDTO> Create([FromBody] AddressCreateDTO createDto)
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
        public ActionResult<IEnumerable<AddressReadDTO>> GetAll()
        {
            return _service.FindAll();
        }

        [HttpGet("id=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AddressReadDTO> GetById(int id)
        {
            return _service.FindById(id);
        }

        [HttpPatch("update:id={id}&address=")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AddressReadDTO> UpdateQuantities(int id, AddressCreateDTO address)
        {
            return _service.Update(id, address); ;
        }
    }
}
