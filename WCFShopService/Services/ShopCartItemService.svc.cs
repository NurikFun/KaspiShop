using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ShopCartItemService : IShopCartItemService
    {
        private List<ShopCartLineDTO> lineCollection = new List<ShopCartLineDTO>();
        public void AddItem(ProductDTO product, int quantity, string locationName)
        {
            ShopCartLineDTO line = lineCollection
                .Where(p => p.ProductDTO.ProductID == product.ProductID && p.LocationName == locationName)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new ShopCartLineDTO
                {
                    ProductDTO = product,
                    Quantity = quantity,
                    LocationName = locationName
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Quantity * x.ProductDTO.ListPrice);
        }

        public void RemoveLine(ProductDTO product, string locationName)
        {
            lineCollection.RemoveAll(x => x.ProductDTO.ProductID == product.ProductID && x.LocationName == locationName);
        }

        public IEnumerable<ShopCartLineDTO> Lines()
        {
            return lineCollection;
        }

    }


}
