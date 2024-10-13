using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class SupplyService : IEntityService<Supply>
{
    private readonly List<Supply> _supplies = [];

    private int _id = 1;

    public List<Supply> GetAll() => _supplies;

    public Supply? GetById(int id) => _supplies.FirstOrDefault(o => o.Id == id);

    public Supply Add(Supply supply)
    {
        supply.Id = _id++;
        _supplies.Add(supply);
        return supply;
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

    public bool Update(Supply updatedSupply)
    {
        var supply = GetById(updatedSupply.Id);
        if (supply == null)
        {
            return false;
        }
        supply.Product = updatedSupply.Product;
        supply.Organization = updatedSupply.Organization;
        supply.SupplyDate = updatedSupply.SupplyDate;
        supply.Quantity = updatedSupply.Quantity;
        return true;
    }
}
