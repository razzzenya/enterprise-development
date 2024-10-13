using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class ProductService : IEntityService<Product>
{
    private readonly List<Product> _products = [];

    private int _id = 1;

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(o => o.Id == id);

    public Product Add(Product product)
    {
        product.Id = _id++;
        _products.Add(product);
        return product;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        _products.Remove(product);
        return true;
    }

    public bool Update(Product updatedProduct)
    {
        var product = GetById(updatedProduct.Id);
        if (product == null)
        {
            return false;
        }
        product.Name = updatedProduct.Name;
        product.Code = updatedProduct.Code;
        return true;
    }
}
