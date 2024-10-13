using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class CellService : IEntityService<Cell>
{
    private readonly List<Cell> _cells = [];

    private int _id = 1;

    public List<Cell> GetAll() => _cells;
    public Cell? GetById(int id) => _cells.FirstOrDefault(o => o.Id == id);

    public Cell Add(Cell cell)
    {
        cell.Id = _id++;
        _cells.Add(cell);
        return cell;
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

    public bool Update(Cell updatedCell)
    {
        var cell = GetById(updatedCell.Id);
        if (cell == null)
        {
            return false;
        }
        cell.Product = updatedCell.Product;
        cell.Quantity = updatedCell.Quantity;
        return true;
    }
}
