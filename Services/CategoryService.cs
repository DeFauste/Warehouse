using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Dto;
using Warehouse.Data.Entity;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<CategoryReadDTO> Create(CategoryCreateDTO createDto)
        {
            if (createDto == null)
                return new BadRequestObjectResult("Object cannot be null")
                { StatusCode = StatusCodes.Status400BadRequest };

            try
            {
                var entity = _mapper.Map<CategoryEntity>(createDto);

                _repository.Create(entity);
                _repository.SaveChange();
                var readDto = _mapper.Map<CategoryReadDTO>(entity);

                return new OkObjectResult("New category added")
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

            return new OkObjectResult($"Category with Guid {id} deleted")
            { StatusCode = StatusCodes.Status200OK };
        }
        public ActionResult<IEnumerable<CategoryReadDTO>> FindAll()
        {
            var listEntity = _repository.FindAll();
            var listReadDto = _mapper.Map<List<CategoryReadDTO>>(listEntity);

            return new OkObjectResult(listReadDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<CategoryReadDTO> FindById(int id)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var readDto = _mapper.Map<CategoryReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }

        public ActionResult<CategoryReadDTO> Update(int id, CategoryCreateDTO newData)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
                return new ObjectResult($"The object with the Guid {id} was not found")
                { StatusCode = StatusCodes.Status404NotFound };

            var newEntiry = _mapper.Map<CategoryEntity>(newData);

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
            var readDto = _mapper.Map<CategoryReadDTO>(entity);

            return new OkObjectResult(readDto)
            { StatusCode = StatusCodes.Status200OK };
        }
    }
}

