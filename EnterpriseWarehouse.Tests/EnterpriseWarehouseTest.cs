using EnterpiseWarehouse;
using System.Security.Cryptography;

namespace EnterpriseWarehouse.Tests
{
    public class EnterpriseWarehouseTest(WarehouseFixture fixture) : IClassFixture<WarehouseFixture>
    {
        private readonly WarehouseFixture _fixture = fixture;

        [Fact]
        public void ReturnAllProductsSortedByName()
        {
            var sortedProducts = _fixture.Warehouse.Values.OrderBy(p => p.name).ToList();
            Assert.True(IsSortedByName(sortedProducts), "Products are not sorted by name");
        }

        private bool IsSortedByName(List<Product> products)
        {
            for (int i = 1; i < products.Count; i++)
            {
                if (string.Compare(products[i - 1].name, products[i].name) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        [Fact]
        public void ReturnProductsRecieveOnDate()
        {
            DateTime date = new(2021, 6, 12);
            string name = "Beta Distributors";
            List<Product> products = _fixture.Supplies
                .Where(s => s.organization.name == name && s.supplyDate == date)
                .Select(s => s.product)
                .ToList();
            Assert.Equal(new List<Product> { _fixture.Warehouse[3] }, products);
        }

        [Fact]
        public void ReturnCurrentWarehouseState()
        {
            var warehouseData = _fixture.Warehouse
                .Select(entry => new
                {
                    CellId = entry.Key,
                    Product = entry.Value
                })
                .ToList();
            var expectedData = new List<object>
            {
                new { CellId = 0, Product = _fixture.Products[0] },
                new { CellId = 1, Product = _fixture.Products[1] },
                new { CellId = 2, Product = _fixture.Products[2] },
                new { CellId = 3, Product = _fixture.Products[3] },
                new { CellId = 4, Product = _fixture.Products[4] },
                new { CellId = 5, Product = _fixture.Products[5] },
                new { CellId = 6, Product = _fixture.Products[6] },
                new { CellId = 7, Product = _fixture.Products[7] },
                new { CellId = 8, Product = _fixture.Products[8] },
                new { CellId = 9, Product = _fixture.Products[9] },
                new { CellId = 10, Product = _fixture.Products[10] },
                new { CellId = 11, Product = _fixture.Products[11] }
            };
            Assert.Equal(expectedData, warehouseData);
        }

        [Fact]
        public void ReturnMaxSuppliesOrganizations()
        {
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);
            var organizationsWithMaxSupply = _fixture.Supplies
                .Where(s => s.supplyDate >= startDate && s.supplyDate <= endDate)
                .GroupBy(s => s.organization)
                .Select(g => new
                {
                    Organization = g.Key,
                    TotalQuantity = g.Sum(s => s.quantity ?? 0)
                })
                .OrderByDescending(o => o.TotalQuantity)
                .ToList();
            int maxQuantity = organizationsWithMaxSupply.FirstOrDefault()?.TotalQuantity ?? 0;
            var result = organizationsWithMaxSupply
                .Where(o=>o.TotalQuantity == maxQuantity)
                .Select(o => o.Organization)
                .ToList();

            Assert.Equal(new List<Organization> { _fixture.Organizations[6] }, result);
        }
    }
}