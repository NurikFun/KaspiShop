using AW.Domain.Core;
using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Data.CustomRepository
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {

        private AWContext context = new AWContext();
        public IEnumerable<ProductCatalog> GetList()
        {
            var productCatalog = (
                                    from p in context.Product
                                    join pri in context.ProductInventory on p.ProductID equals pri.ProductID
                                    join prl in context.Location on pri.LocationID equals prl.LocationID
                                    join prm in context.ProductModel on p.ProductModelID equals prm.ProductModelID
                                    join prmprd in context.ProductModelProductDescriptionCulture on prm.ProductModelID equals prmprd.ProductModelID
                                    join prd in context.ProductDescription on prmprd.ProductDescriptionID equals prd.ProductDescriptionID
                                    join prsc in context.ProductSubcategory on p.ProductSubcategoryID equals prsc.ProductSubcategoryID
                                    join prc in context.ProductCategory on prsc.ProductCategoryID equals prc.ProductCategoryID
                                    join prph in context.ProductProductPhoto on p.ProductID equals prph.ProductID
                                    where prmprd.CultureID.Contains("en") && pri.Quantity > 0
                                    select new ProductCatalog
                                    {
                                        ID = p.ProductID,
                                        Name = p.Name,
                                        Color = p.Color,
                                        Description = prd.Description,
                                        Quantity = pri.Quantity,
                                        Location = prl.Name,
                                        SubCategory = prsc.Name,
                                        PhotoID = prph.ProductPhotoID,
                                        Price = p.ListPrice
                                    }
                );
            return productCatalog.ToList();
        }
    }
}
