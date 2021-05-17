using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Data.CustomRepository;
using AW.Infrastructure.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace WCFShopService
{
    public class Test : ITest
    {

        private IRepository<ProductCategory> repository;

        public Test(IRepository<ProductCategory> repository)
        {
            this.repository = repository;
        }

        public List<ProductCategoryTest> GetAllProducts()
        {
            var values = repository.GetList().ToList();

            List<ProductCategoryTest> test = new List<ProductCategoryTest>();
            
            foreach (var item in values)
            {
                var sub = item.ProductSubcategories.ToList();

                List<string> subCat = new List<string>();
                foreach (var value in sub)
                {
                    subCat.Add(value.Name);
                }

                test.Add(new ProductCategoryTest { 
                    Name = item.Name,
                    ProductSubcategories = subCat
                });
            }

            return test;
        }

    }
}
