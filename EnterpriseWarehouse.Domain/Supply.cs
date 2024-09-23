namespace EnterpiseWarehouse.Domain;
/// <summary>
/// Поставка товара
/// </summary>
public class Supply
{
    /// <summary>
    /// Товар
    /// </summary>
    public required Product Product { get; set; }
    /// <summary>
    /// Организация
    /// </summary>
    public required Organization Organization { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public DateTime? SupplyDate { get; set; }
    /// <summary>
    /// Количество поставленного товара
    /// </summary>
    public int? Quantity { get; set; }
}

