using EnterpiseWarehouse;

namespace EnterpriseWarehouse.Tests
{
    public class WarehouseFixture
    {
        public List<Organization> Organizations =
        [
            new() {name = "TechCorp" , address = "123 Main St, Springfield"},
            new() {name = "Innovate Solutions", address = "456 Elm St, Metropolis"},
            new() {name = "Alpha Logistics", address = "789 Oak St, Gotham"},
            new() {name = "Beta Distributors", address = "101 Maple Ave, Star City"},
            new() {name = "Global Trade Ltd", address = "202 Birch St, Central City"},
            new() {name = "Enterprise Inc.", address = "303 Cedar St, Keystone City"},
            new() {name = "Techno Group", address = "404 Pine St, Coast City"},
            new() {name = "Smart Systems", address = "505 Willow Ave, Blüdhaven"},
            new() {name = "Quantum Enterprises", address = "606 Redwood St, Hub City"},
            new() {name = "GreenEnergy Corp", address = "707 Cypress St, Fawcett City"}
        ];

        public List<Product> Products =
        [
            new() {id = 1, name = "Laptop", quantity = 8, cellId = 0},
            new() {id = 2, name = "Tablet", quantity = 6, cellId = 1},
            new() {id = 3, name = "Monitor", quantity = 2, cellId = 2},
            new() {id = 4, name = "Keyboard", quantity = 15, cellId = 3},
            new() {id = 5, name = "Mouse", quantity = 3, cellId = 4},
            new() {id = 1, name = "Laptop", quantity = 7, cellId = 5},
            new() {id = 6, name = "Printer", quantity = 10, cellId = 6},
            new() {id = 7, name = "Smartphone", quantity = 20, cellId = 7},
            new() {id = 8, name = "Router", quantity = 13, cellId = 8},
            new() {id = 9, name = "Headphones", quantity = 1, cellId = 9},
            new() {id = 3, name = "Monitor", quantity = 20, cellId = 10},
            new() {id = 10, name = "Webcam", quantity = 16, cellId = 11}
        ];

        public List<Supply> Supplies;

        public Dictionary<int, Product> Warehouse = new();
        public WarehouseFixture()
        {
            Supplies =
            [
                new() {product = Products[0], organization = Organizations[0], quantity = 3, supplyDate = new DateTime(2015, 2, 3) },
                new() {product = Products[1], organization = Organizations[1], quantity = 16, supplyDate = new DateTime(2022, 11, 15) },
                new() {product = Products[2], organization = Organizations[2], quantity = 8, supplyDate = new DateTime(2019, 7, 22) },
                new() {product = Products[3], organization = Organizations[3], quantity = 5, supplyDate = new DateTime(2021, 6, 12) },
                new() {product = Products[4], organization = Organizations[4], quantity = 19, supplyDate = new DateTime(2021, 10, 9) },
                new() {product = Products[5], organization = Organizations[5], quantity = 33, supplyDate = new DateTime(2013, 1, 28) },
                new() {product = Products[6], organization = Organizations[6], quantity = 159, supplyDate = new DateTime(2015, 4, 5) },
                new() {product = Products[7], organization = Organizations[7], quantity = 1, supplyDate = new DateTime(2011, 8, 14) },
                new() {product = Products[4], organization = Organizations[7], quantity = 6, supplyDate = new DateTime(2016, 4, 12) },
                new() {product = Products[4], organization = Organizations[7], quantity = 16, supplyDate = new DateTime(2013, 2, 15) }

            ];
            Warehouse.Add(0, Products[0]);
            Warehouse.Add(1, Products[1]);
            Warehouse.Add(2, Products[2]);
            Warehouse.Add(3, Products[3]);
            Warehouse.Add(4, Products[4]);
            Warehouse.Add(5, Products[5]);
            Warehouse.Add(6, Products[6]);
            Warehouse.Add(7, Products[7]);
            Warehouse.Add(8, Products[8]);
            Warehouse.Add(9, Products[9]);
            Warehouse.Add(10, Products[10]);
            Warehouse.Add(11, Products[11]);
        }
    }
}
