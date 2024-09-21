using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Supply
    {
        public Product? product { get; set; }
        public Organization? organization { get; set; }
        public DateTime? supplyDate { get; set; }
        public int? quantity { get; set; }
    }
}
