using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpiseWarehouse;
/// <summary>
/// Товар
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int id { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public required string name { get; set; }
    /// <summary>
    /// Количество на складе
    /// </summary>
    public int? quantity { get; set; }
    /// <summary>
    /// Номер ячейки
    /// </summary>
    public int? cellId { get; set; }
}

