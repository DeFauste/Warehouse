using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Data.Entity;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<AddressReadDTO> Create(AddressCreateDTO createDto)
        {
            if (createDto == null)
                return new BadRequestObjectResult("Object cannot be null")
                { StatusCode = StatusCodes.Status400BadRequest };

            try
            {
                var entity = _mapper.Map<AddressEntity>(createDto);
               
                _repository.Create(entity);
                _repository.SaveChange();
                var readDto = _mapper.Map<AddressReadDTO>(entity);

                return new OkObjectResult("New address added")
                { StatusCode = StatusCodes.Status201Created, Value = readDto };
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Invalid data")
                { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
        public ActionResult DeleteById(int id)
        {
            if (id < 0)
                return new ObjectResult($"The object with the Guid {id} was not exist")
                { StatusCode = StatusCodes.Status404NotFound };

            try
            {
                _repository.DeleteById(id);
                _repository.SaveChange();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex)
                { StatusCode = StatusCodes.Status400BadRequest };
            }

            return new OkObjectResult($"Address with Guid {id} deleted")
            { StatusCode = StatusCodes.Status200OK };
        }
        public ActionResult<IEnumerable<AddressReadDTO>> FindAll()
        {
            var listEntity = _repository.FindAll();
            var listReadDto = _mapper.Map<List<AddressReadDTO>>(listEntity);

            return new OkObjectResult(listReadDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<AddressReadDTO> FindById(int id)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var readDto = _mapper.Map<AddressReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<AddressReadDTO> Update(int id, AddressCreateDTO newData)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var newEntiry = _mapper.Map<AddressEntity>(newData);
            try
            {
                _repository.Update(id, newEntiry);
                _repository.SaveChange();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex)
                { StatusCode = StatusCodes.Status400BadRequest };
            }

            var readDto = _mapper.Map<AddressReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }
    }
}
