namespace EnterpriseWarehouse.API.DTO;
/// <summary>
/// DTO описывающее количество товара поставленного организации
/// </summary>
public class ProductSupplyToOrganizationsDTO
{
    public int TotalQuantity { get; set; }
    public required string ProductName { get; set; }
    public required string OrganizationName { get; set; }
}
