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
    public class ProductService : IProductService
    {
        private IRepository<Product> repository;
        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }
        public ProductDTO GetProduct(int productID)
        {
            var value = repository.GetList().FirstOrDefault(p => p.ProductID == productID);

            ProductDTO result = new ProductDTO
            {
                Name = value.Name,
                ProductID = value.ProductID,
                ListPrice = value.ListPrice
            };
            return result;
        }
    }
}
