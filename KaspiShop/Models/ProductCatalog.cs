using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Models
{
    public class ProductCatalog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public byte[] Photo { get; set; }
        public string SubCategory { get; set; }
        public decimal Price { get; set; }
    }
}