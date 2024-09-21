namespace EnterpiseWarehouse;
/// <summary>
/// Поставка товара
/// </summary>
public class Supply
{
    /// <summary>
    /// Товар
    /// </summary>
    public required Product product { get; set; }
    /// <summary>
    /// Организация
    /// </summary>
    public required Organization organization { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public DateTime? supplyDate { get; set; }
    /// <summary>
    /// Количество поставленного товара
    /// </summary>
    public int? quantity { get; set; }
}

