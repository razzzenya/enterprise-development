using AutoMapper;
using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;
namespace EnterpriseWarehouse.API.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Organization, OrganizationDTO>();
        CreateMap<OrganizationDTO, Organization>();
        CreateMap<Organization, OrganizationCreateDTO>();
        CreateMap<OrganizationCreateDTO, Organization>();

        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductCreateDTO>();
        CreateMap<ProductCreateDTO, Product>();

        CreateMap<Cell, CellDTO>();
        CreateMap<CellDTO, Cell>();

        CreateMap<Supply, SupplyDTO>();
        CreateMap<SupplyDTO, Supply>(); 
    }
}
