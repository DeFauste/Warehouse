using AutoMapper;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Dto.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // Source-- > Target
            //Address
            CreateMap<AddressEntity, AddressReadDTO>();
            CreateMap<AddressCreateDTO, AddressEntity>();
            //Category
            CreateMap<CategoryEntity, CategoryReadDTO>();
            CreateMap<CategoryCreateDTO, CategoryEntity>();
            //Product
            CreateMap<ProductEntity, ProductReadDTO>();
            CreateMap<ProductCreateDTO, ProductEntity>();
            //Supplier
            CreateMap<SupplierEntity, SupplierReadDTO>();
            CreateMap<SupplierCreateDTO, SupplierEntity>();
        }
    }
}
