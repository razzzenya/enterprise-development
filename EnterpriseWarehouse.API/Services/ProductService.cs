using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class ProductService : IEntityService<Product, ProductCreateDTO, ProductDTO>
{
    private readonly List<Product> _products = [];

    private int _id = 1;

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(o => o.Id == id);

    public bool Add(ProductCreateDTO newProduct)
    {
        var product = new Product
        {
            Id = _id++,
            Name = newProduct.Name,
            Code = newProduct.Code,
        };
        _products.Add(product);
        return true;
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

    public bool Update(ProductDTO updatedProduct)
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
