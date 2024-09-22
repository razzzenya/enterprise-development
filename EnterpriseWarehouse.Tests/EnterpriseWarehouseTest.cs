namespace EnterpriseWarehouse.Tests
{
    public class EnterpriseWarehouseTest(WarehouseFixture fixture) : IClassFixture<WarehouseFixture>
    {
        private readonly WarehouseFixture _fixture = fixture;

        [Fact]
        public void TestQuery()
        {

        }
    }
}