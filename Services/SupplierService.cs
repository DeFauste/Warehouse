using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Data.Entity;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<SupplierReadDTO> Create(SupplierCreateDTO createDto)
        {
            if (createDto == null)
                return new BadRequestObjectResult("Object cannot be null")
                { StatusCode = StatusCodes.Status400BadRequest };

            try
            {
                var entity = _mapper.Map<SupplierEntity>(createDto);

                _repository.Create(entity);
                _repository.SaveChange();
                var readDto = _mapper.Map<SupplierReadDTO>(entity);

                return new OkObjectResult("New supplier added")
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

            return new OkObjectResult($"Supplier with Guid {id} deleted")
            { StatusCode = StatusCodes.Status200OK };
        }
        public ActionResult<IEnumerable<SupplierReadDTO>> FindAll()
        {
            var listEntity = _repository.FindAll();
            var listReadDto = _mapper.Map<List<SupplierReadDTO>>(listEntity);

            return new OkObjectResult(listReadDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<SupplierReadDTO> FindById(int id)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var readDto = _mapper.Map<SupplierReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<SupplierReadDTO> Update(int id, SupplierCreateDTO newData)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var newEntiry = _mapper.Map<SupplierEntity>(newData);
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
            var readDto = _mapper.Map<SupplierReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }
    }
}
