namespace EnterpiseWarehouse.Domain;
/// <summary>
/// Ячейка склада
/// </summary>
public class Cell
{
    /// <summary>
    /// Идентификатор ячейки
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    public required Product Product { get; set; }
    /// <summary>
    /// Количество товара в ячейке
    /// </summary>
    public int? Quantity { get; set; }

}
