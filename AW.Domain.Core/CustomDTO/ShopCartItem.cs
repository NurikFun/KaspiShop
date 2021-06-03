using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Core
{
    public class ShopCartItem
    {
        private List<ShopCartLine> lineCollection = new List<ShopCartLine>();

        public void AddItem(Product product, int quantity)
        {
            ShopCartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new ShopCartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public IEnumerable<ShopCartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class ShopCartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
