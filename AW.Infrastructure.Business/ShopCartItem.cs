using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Business
{
    public class ShopCartItem
    {
        private List<ShopCartLine> lineCollection = new List<ShopCartLine>();

        public void AddItem(Product product, int quantity, string locationName)
        {
            ShopCartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID && p.LocationName == locationName)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new ShopCartLine
                {
                    Product = product,
                    Quantity = quantity,
                    LocationName = locationName
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product, string locationName)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID && l.LocationName == locationName);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.ListPrice * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
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
        public string LocationName { get; set; }
    }
}
