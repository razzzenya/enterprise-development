namespace EnterpriseWarehouse.API.DTO;
/// <summary>
/// DTO описывающее продукт и его количество на складе
/// </summary>
public class ProductQuantityDTO
{
    public string? ProductName { get; set; }

    public int Quantity { get; set; }
}
