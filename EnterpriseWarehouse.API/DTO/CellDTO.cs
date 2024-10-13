namespace EnterpriseWarehouse.API.DTO;

/// <summary>
/// DTO ячейки
/// </summary>
public class CellDTO
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public required int ProductId { get; set; }
    /// <summary>
    /// Количество товара в ячейке
    /// </summary>
    public required int Quantity { get; set; }
}
