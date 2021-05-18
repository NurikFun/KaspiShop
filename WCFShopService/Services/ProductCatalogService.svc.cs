using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductCatalogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductCatalogService.svc or ProductCatalogService.svc.cs at the Solution Explorer and start debugging.
    public class ProductCatalogService : IProductCatalogService
    {
        private IProductCatalogRepository repository; 
        public ProductCatalogService(IProductCatalogRepository repository)
        {
            this.repository = repository;
        }
        public List<ProductCatalogDTO> GetList()
        {
            var values = repository.GetList();

            List<ProductCatalogDTO> result = new List<ProductCatalogDTO>();

            foreach (var value in values)
            {
                result.Add(new ProductCatalogDTO { 
                    ID = value.ID,
                    Name = value.Name,
                    Color = value.Color,
                    Description = value.Description,
                    Quantity = value.Quantity,
                    Location = value.Location,
                    SubCategory = value.SubCategory,
                    PhotoID = value.PhotoID,
                    Price = value.Price
                });
            }
            return result;
        }
    }
}
