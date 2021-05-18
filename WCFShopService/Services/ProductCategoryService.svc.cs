using AW.Domain.Core;
using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductCategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductCategoryService.svc or ProductCategoryService.svc.cs at the Solution Explorer and start debugging.
    public class ProductCategoryService : IProductCategoryService
    {
        private IRepository<ProductCategory> repository;
        public ProductCategoryService(IRepository<ProductCategory> repository)
        {
            this.repository = repository;
        }

        public List<ProductCategoryDTO> GetList()
        {
            var values = repository.GetList();

            List<ProductCategoryDTO> result = new List<ProductCategoryDTO>();

            foreach (var value in values)
            {
                var subcat = new List<ProductSubcategoryDTO>();
                foreach (var item in value.ProductSubcategories)
                {
                    subcat.Add(new ProductSubcategoryDTO { Name = item.Name });
                }
                result.Add(new ProductCategoryDTO
                {
                    Name = value.Name,
                    SubCategories = subcat
                });
            }

            return result;
        }
    }
}
