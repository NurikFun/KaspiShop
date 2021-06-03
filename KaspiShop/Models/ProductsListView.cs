using AW.Domain.Core;
using KaspiShop.ProductCatalogService;
using KaspiShop.ShopCartItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Models
{
    public class ProductsListView
    {
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<ProductCatalogDTO> ProductCatalog { get; set; }
        public ShopCartItemServiceClient Cart { get; set; }

        public void CountActualProduct()
        {
            var dto = Cart.Lines();
            foreach (var value in ProductCatalog)
            {                
                value.Quantity -= dto.Where(x => x.ProductDTO.ProductID == value.ID)
                    .Select(q => q.Quantity).FirstOrDefault();
            }
        }

    }
}