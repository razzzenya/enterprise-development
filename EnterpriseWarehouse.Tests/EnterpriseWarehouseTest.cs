using EnterpiseWarehouse.Domain;

namespace EnterpriseWarehouse.Tests
{
    public class EnterpriseWarehouseTest(WarehouseFixture fixture) : IClassFixture<WarehouseFixture>
    {
        private readonly WarehouseFixture _fixture = fixture;

        [Fact]
        public void ReturnAllProductsSortedByName()
        {
            List<Product> expectedData =
            [
                _fixture.Cells[9].Product,
                _fixture.Cells[3].Product,
                _fixture.Cells[0].Product,
                _fixture.Cells[5].Product,
                _fixture.Cells[2].Product,
                _fixture.Cells[10].Product,
                _fixture.Cells[4].Product,
                _fixture.Cells[6].Product,
                _fixture.Cells[8].Product,
                _fixture.Cells[7].Product,
                _fixture.Cells[1].Product,
                _fixture.Cells[11].Product
            ];
            var sortedProducts = _fixture.Cells
                .OrderBy(c => c.Product.Name)
                .Select(c => c.Product)
                .ToList();
            Assert.Equal(expectedData, sortedProducts);
        }

        [Fact]
        public void ReturnProductsRecieveOnDate()
        {
            var date = new DateTime(2021, 6, 12);
            var name = "Beta Distributors";
            var products = _fixture.Supplies
                .Where(s => s.Organization.Name == name && s.SupplyDate == date)
                .Select(s => s.Product)
                .ToList();
            Assert.Equal([ _fixture.Cells[3].Product ], products);
        }

        [Fact]
        public void ReturnCurrentWarehouseState()
        {
            var expectedData = new[]
{
                new { CellId = 0, _fixture.Cells[0].Product, Quantity = _fixture.Cells[0].Quantity ?? 0 },
                new { CellId = 1, _fixture.Cells[1].Product, Quantity = _fixture.Cells[1].Quantity ?? 0 },
                new { CellId = 2, _fixture.Cells[2].Product, Quantity = _fixture.Cells[2].Quantity ?? 0 },
                new { CellId = 3, _fixture.Cells[3].Product, Quantity = _fixture.Cells[3].Quantity ?? 0 },
                new { CellId = 4, _fixture.Cells[4].Product, Quantity = _fixture.Cells[4].Quantity ?? 0 },
                new { CellId = 5, _fixture.Cells[5].Product, Quantity = _fixture.Cells[5].Quantity ?? 0 },
                new { CellId = 6, _fixture.Cells[6].Product, Quantity = _fixture.Cells[6].Quantity ?? 0 },
                new { CellId = 7, _fixture.Cells[7].Product, Quantity = _fixture.Cells[7].Quantity ?? 0 },
                new { CellId = 8, _fixture.Cells[8].Product, Quantity = _fixture.Cells[8].Quantity ?? 0 },
                new { CellId = 9, _fixture.Cells[9].Product, Quantity = _fixture.Cells[9].Quantity ?? 0 },
                new { CellId = 10, _fixture.Cells[10].Product, Quantity = _fixture.Cells[10].Quantity ?? 0},
                new { CellId = 11, _fixture.Cells[11].Product, Quantity = _fixture.Cells[11].Quantity ?? 0 }
            }.ToList();

            var warehouseData = _fixture.Cells
                .Select(entry => new
                {
                    CellId = entry.Id,
                    Product = entry.Product,
                    Quantity = entry.Quantity ?? 0
                    
                })
                .ToList();
            Assert.Equal(expectedData, warehouseData);
        }

        [Fact]
        public void ReturnMaxSuppliesOrganizations()
        {
            var startDate = new DateTime(2010, 1, 1);
            var endDate = new DateTime(2023, 12, 31);
            var organizationsWithMaxSupply = _fixture.Supplies
                .Where(s => s.SupplyDate >= startDate && s.SupplyDate <= endDate)
                .GroupBy(s => s.Organization)
                .Select(g => new
                {
                    Organization = g.Key,
                    TotalQuantity = g.Sum(s => s.Quantity ?? 0)
                })
                .OrderByDescending(o => o.TotalQuantity)
                .ToList();
            var maxQuantity = organizationsWithMaxSupply.MaxBy(o => o.TotalQuantity)?.TotalQuantity ?? 0;
            var result = organizationsWithMaxSupply
                .Where(o => o.TotalQuantity == maxQuantity)
                .Select(o => o.Organization)
                .ToList();

            Assert.Equal([_fixture.Organizations[6]], result);
        }

        [Fact]
        public void ReturnFiveMaxQuantityProducts()
        {
            var products = _fixture.Cells
                .GroupBy(c => c.Product.Name)
                .Select(g => new
                {
                    ProductName = g.Key,
                    Quantity = g.Sum(c => c.Quantity ?? 0),
                })
                .OrderByDescending(p => p.Quantity)
                .Take(5)
                .ToList();

            Assert.Equal("Monitor", products[0].ProductName);
            Assert.Equal(22, products[0].Quantity);
            Assert.Equal("Smartphone", products[1].ProductName);
            Assert.Equal(20, products[1].Quantity);
            Assert.Equal("Webcam", products[2].ProductName);
            Assert.Equal(16, products[2].Quantity);
            Assert.Equal("Laptop", products[3].ProductName);
            Assert.Equal(15, products[3].Quantity);
            Assert.Equal("Keyboard", products[4].ProductName);
            Assert.Equal(15, products[4].Quantity);
        }

        [Fact]
        public void ReturnQuantityProductSupplyToOrganiztions()
        {
            var expectedData = new[]
            {
                new{ TotalQuantity = 159, ProductName = "Printer", OrganizationName = "Techno Group" },
                new{ TotalQuantity = 33, ProductName = "Laptop", OrganizationName = "Enterprise Inc." },
                new{ TotalQuantity = 22, ProductName = "Mouse", OrganizationName = "Smart Systems" },
                new{ TotalQuantity = 19, ProductName = "Mouse", OrganizationName = "Global Trade Ltd" },
                new{ TotalQuantity = 16, ProductName = "Tablet", OrganizationName = "Innovate Solutions" },
                new{ TotalQuantity = 8, ProductName = "Monitor", OrganizationName = "Alpha Logistics" },
                new{ TotalQuantity = 5, ProductName = "Keyboard", OrganizationName = "Beta Distributors" },
                new{ TotalQuantity = 3, ProductName = "Laptop", OrganizationName = "TechCorp" },
                new{ TotalQuantity = 1, ProductName = "Smartphone", OrganizationName = "Smart Systems" }

            };

            var info = _fixture.Supplies
                .GroupBy(p => new { ProductName = p.Product.Name, OrganizationName = p.Organization.Name })
                .Select(g => new
                {
                    TotalQuantity = g.Sum(p => p.Quantity ?? 0),
                    g.Key.ProductName,
                    g.Key.OrganizationName,
                })
                .OrderByDescending(p => p.TotalQuantity)
                .ToList();

            Assert.Equal(expectedData, info);
        }
    }
}