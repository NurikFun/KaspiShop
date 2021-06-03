using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Core
{
    public class ProductCatalog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public Int16 Quantity { get; set; }
        public string SubCategory { get; set; }
        public int PhotoID { get; set; }
        public decimal Price { get; set; }
    }
}
