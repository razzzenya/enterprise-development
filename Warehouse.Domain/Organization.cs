using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpiseWarehouse;
/// <summary>
/// Организация
/// </summary>
public class Organization
{
    /// <summary>
    /// Название
    /// </summary>
    public required string name { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string address { get; set; }
}

