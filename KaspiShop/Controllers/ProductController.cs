using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Data;
using KaspiShop.Models;
using KaspiShop.ProductCatalogService;
using KaspiShop.ProductPhotoService;
using KaspiShop.ShopCartItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ProductController : Controller
    {
        private readonly IProductCatalogService dataRepository;
        private readonly IProductPhotoService photoRepository;
        public int PageSize = 4;
        public ProductController(IProductCatalogService dataRepository, IProductPhotoService photoRepository, 
            IShopCartItemService shopCartItemService)
        {
            this.dataRepository = dataRepository;
            this.photoRepository = photoRepository;
        }

        public ActionResult List(ShopCartItemServiceClient cart, string category, string subcategory, int page = 1, string name = null)
        {

            ProductsListView productsList = new ProductsListView
            {
                CurrentCategory = category,
                SubCategory = subcategory,
                ProductName = name,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = name == null ? dataRepository.GetList().Where(x => x.SubCategory == subcategory).Count()
                                              : dataRepository.GetList().Where(x => x.Name.Contains(name)).Count()
                },
                ProductCatalog = subcategory != null ? dataRepository.GetList()
                                   .Where(x => x.SubCategory == subcategory || x.SubCategory == null)
                                   .OrderBy(x => x.ID)
                                   .Skip((page - 1) * PageSize)
                                   .Take(PageSize) : dataRepository.GetList().Where(x => x.Name.Contains(name))
                                   .OrderBy(x => x.ID).Skip((page - 1) * PageSize).Take(PageSize),
                Cart = cart
            };
            productsList.CountActualProduct();
            return View(productsList);
        }


        public FileContentResult GetImage(int photoID)
        {
            var photo = photoRepository.GetPhoto(photoID);
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