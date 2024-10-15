using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class CellService(ProductService productService) : IEntityService<Cell, CellCreateDTO>
{
    private readonly List<Cell> _cells = [];

    private int _id = 1;

    public List<Cell> GetAll() => _cells;

    public Cell? GetById(int id) => _cells.FirstOrDefault(o => o.Id == id);

    public bool Add(CellCreateDTO newCell)
    {
        var product = productService.GetById(newCell.ProductId);
        if (product == null) 
        { 
            return false;
        }
        var cell = new Cell
        {
            Id = _id++,
            Quantity = newCell.Quantity,
            Product = product
        };
        _cells.Add(cell);
        return true;
    }

    public bool Delete(int id)
    {
        var cell = GetById(id);
        if (cell == null)
        {
            return false;
        }
        return _cells.Remove(cell);
    }

    public bool Update(int id, CellCreateDTO updatedCell)
    {
        var cell = GetById(id);
        if (cell == null)
        {
            return false;
        }
        var product = productService.GetById(updatedCell.ProductId);
        if (product == null)
        {
            return false;
        }
        cell.Product = product;
        cell.Quantity = updatedCell.Quantity;
        return true;
    }
}
