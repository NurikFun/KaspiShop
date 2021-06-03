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

        public IEnumerable<ProductCatalog> GetList()
        {
            using (var context = new AWContext())
            {
                var productCatalog = context.Database.SqlQuery<ProductCatalog>(
                    @"select pr.ProductID as ID, pr.Name, pr.Color, prd.Description, temp.Quantity, prsc.Name as SubCategory, prph.ProductPhotoID as PhotoID, pr.ListPrice as Price from Production.Product as pr
                          inner join Production.ProductModel as prm on prm.ProductModelID = pr.ProductModelID
                          inner join Production.ProductModelProductDescriptionCulture as prmprd on prmprd.ProductModelID = prm.ProductModelID
                          inner join Production.ProductDescription as prd on prd.ProductDescriptionID = prmprd.ProductDescriptionID
                          inner join Production.ProductSubcategory as prsc on pr.ProductSubcategoryID = prsc.ProductSubcategoryID
                          inner join Production.ProductCategory as prc on prsc.ProductCategoryID = prc.ProductCategoryID
                          inner join Production.ProductProductPhoto as prph on pr.ProductID = prph.ProductID
                          inner join (
	                        SELECT  ProductID, quantity, roworder from (
	                        select ProductID, quantity, row_number() over(partition by ProductID order by quantity desc) as roworder
	                        from [AdventureWorks2019].[Production].[ProductInventory]
	                        ) innerTemp 
                          ) temp on temp.ProductID = pr.ProductID
                          where prmprd.CultureID like ('%en%') and temp.Quantity > 0 and roworder = 1;").ToList();

                return productCatalog;

            }
        }
    }
}
