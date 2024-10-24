using AutoMapper;
using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;
using EnterpriseWarehouse.Domain.Repositories;

namespace EnterpriseWarehouse.API.Services;

public class SupplyService(SupplyRepository supplyRepository, OrganizationRepository organizationRepository, ProductRepository productRepository, IMapper mapper) : IEntityService<SupplyDTO, SupplyCreateDTO>
{
    public IEnumerable<SupplyDTO> GetAll() => supplyRepository.GetAll().Select(mapper.Map<SupplyDTO>);

    public SupplyDTO? GetById(int id) => mapper.Map<SupplyDTO>(supplyRepository.GetById(id));

    public SupplyDTO? Add(SupplyCreateDTO newSupply)
    {
        var organization = organizationRepository.GetById(newSupply.OrganizationId);
        var product = productRepository.GetById(newSupply.ProductId);
        if (organization == null || product == null)
        {
            return null;
        }
        return mapper.Map<SupplyDTO>(supplyRepository.Add(mapper.Map<Supply>(newSupply)));
    }

    public bool Delete(int id)
    {
        var supply = supplyRepository.GetById(id);
        if (supply == null)
        {
            return false;
        }
        supplyRepository.Delete(supply);
        return true;
    }

    public SupplyDTO? Update(int id, SupplyCreateDTO updatedSupply)
    {
        var supply = supplyRepository.GetById(id);
        if (supply == null)
        {
            return null;
        }
        var product = productRepository.GetById(updatedSupply.ProductId);
        var organization = organizationRepository.GetById(updatedSupply.OrganizationId);
        if (product == null || organization == null)
        {
            return null;
        }
        supply.Product = product;
        supply.Organization = organization;
        supply.SupplyDate = updatedSupply.SupplyDate;
        supply.Quantity = updatedSupply.Quantity;
        return mapper.Map<SupplyDTO>(supplyRepository.Update(supply));
    }
}
