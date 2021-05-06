using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Data;
using KaspiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCatalogRepository dataRepository;
        private readonly IRepository<ProductPhoto> photoRepository;
        public int PageSize = 4;
        public ProductController(IProductCatalogRepository dataRepository, IRepository<ProductPhoto> photoRepository)
        {
            this.dataRepository = dataRepository;
            this.photoRepository = photoRepository;
        }

        public ActionResult List(string category, string subcategory, int page = 1)
        {

            ProductsListView productsList = new ProductsListView
            {
                CurrentCategory = category,
                SubCategory = subcategory,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                            dataRepository.GetList().Count() :
                            dataRepository.GetList().Where(x => x.SubCategory == subcategory).Count()
                },
                ProductCatalog = dataRepository.GetList()
                                   .Where(x => x.SubCategory == subcategory || x.SubCategory == null)
                                   .OrderBy(x => x.ID)
                                   .Skip((page - 1) * PageSize)
                                   .Take(PageSize)
            }; 

            return View(productsList);
        }
        public FileContentResult GetImage(int photoID)
        {
            var photo = photoRepository.GetList(p => p.ProductPhotoID == photoID).FirstOrDefault();
            if (photo != null)
            {
                return File(photo.ThumbNailPhoto, "image/jpg");
            }
            else
            {
                return null;
            }
        }

    }
}