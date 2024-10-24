using EnterpriseWarehouse.Domain.Context;
using EnterpriseWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouse.Domain.Repositories;

public class SupplyRepository(WarehouseContext context) : IEntityRepository<Supply>
{
    public IEnumerable<Supply> GetAll() => context.Supplies;

    public Supply? GetById(int id) => context.Supplies.Find(id);

    public Supply Add(Supply newSupply)
    {
        var supply = context.Supplies.Add(newSupply).Entity;
        context.SaveChanges();
        return supply;
    }

    public void Delete(Supply supply)
    {
        context.Supplies.Remove(supply);
        context.SaveChanges();
    }

    public Supply Update(Supply updatedSupply)
    {
        var entry = context.Entry(updatedSupply);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
