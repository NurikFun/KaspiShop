using AW.Domain.Core;
using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductPhotoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductPhotoService.svc or ProductPhotoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductPhotoService : IProductPhotoService
    {
        private IRepository<ProductPhoto> repository;
        public ProductPhotoService(IRepository<ProductPhoto> repository)
        {
            this.repository = repository;
        }

        public ProductPhotoDTO GetPhoto(int photoID)
        {
            var value = repository.GetList(p => p.ProductPhotoID == photoID).FirstOrDefault();

            ProductPhotoDTO result = new ProductPhotoDTO
            {
                ProductPhotoID = value.ProductPhotoID,
                ThumbNailPhoto = value.ThumbNailPhoto
            };
            return result;
        }

    }
}
