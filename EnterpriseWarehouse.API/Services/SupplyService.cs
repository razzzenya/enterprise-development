using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class SupplyService(ProductService productService, OrganizationService organizationService) : IEntityService<Supply, SupplyCreateDTO, SupplyDTO>
{
    private readonly List<Supply> _supplies = [];

    private int _id = 1;

    public List<Supply> GetAll() => _supplies;

    public Supply? GetById(int id) => _supplies.FirstOrDefault(o => o.Id == id);

    public bool Add(SupplyCreateDTO newSupply)
    {
        var organization = organizationService.GetById(newSupply.OrganizationId);
        var product = productService.GetById(newSupply.ProductId);
        if (organization == null || product == null)
        {
            return false;
        }
        var supply = new Supply
        {
            Id = _id++,
            Organization = organization,
            Product = product,
            SupplyDate = newSupply.SupplyDate,
            Quantity = newSupply.Quantity
        };
        _supplies.Add(supply);
        return true;
    }

    public bool Delete(int id)
    {
        var supply = GetById(id);
        if (supply == null)
        {
            return false;
        }
        _supplies.Remove(supply);
        return true;
    }

    public bool Update(SupplyDTO updatedSupply)
    {
        var supply = GetById(updatedSupply.Id);
        if (supply == null)
        {
            return false;
        }
        var product = productService.GetById(updatedSupply.ProductId);
        var organization = organizationService.GetById(updatedSupply.OrganizationId);
        if (product == null || organization == null)
        {
            return false;
        }
        supply.Product = product;
        supply.Organization = organization;
        supply.SupplyDate = updatedSupply.SupplyDate;
        supply.Quantity = updatedSupply.Quantity;
        return true;
    }
}
