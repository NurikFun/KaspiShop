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

        private readonly IRepository<Product> productRepo;
        private readonly IRepository<ProductInventory> inventoryRepo;
        private readonly IRepository<Location> locationRepo;
        private readonly IRepository<ProductProductPhoto> productPhotoRepo;
        private readonly IRepository<ProductPhoto> photoRepo;
        private readonly IRepository<ProductModel> modelRepo;
        private readonly IRepository<ProductModelProductDescriptionCulture> modelDescriptionRepo;
        private readonly IRepository<ProductDescription> descriptionRepo;
        private readonly IRepository<ProductCategory> productCategoryRepo;
        private readonly IRepository<ProductSubcategory> productSubCategoryRepo;

        public int PageSize = 4;
        public ProductController(IRepository<Product> productRepo, IRepository<ProductInventory> inventoryRepo, IRepository<Location> locationRepo,
            IRepository<ProductProductPhoto> productPhotoRepo, IRepository<ProductPhoto> photoRepo, IRepository<ProductModel> modelRepo,
            IRepository<ProductModelProductDescriptionCulture> modelDescriptionRepo, IRepository<ProductDescription> descriptionRepo,
            IRepository<ProductCategory> productCategoryRepo, IRepository<ProductSubcategory> productSubCategoryRepo
            )
        {
            this.productRepo = productRepo;
            this.inventoryRepo = inventoryRepo;
            this.locationRepo = locationRepo;
            this.productPhotoRepo = productPhotoRepo;
            this.photoRepo = photoRepo;
            this.modelRepo = modelRepo;
            this.modelDescriptionRepo = modelDescriptionRepo;
            this.descriptionRepo = descriptionRepo;
            this.productCategoryRepo = productCategoryRepo;
            this.productSubCategoryRepo = productSubCategoryRepo;
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
                            ProductItems().Count() :
                            ProductItems().Where(x => x.SubCategory == subcategory).Count()
                },
                ProductCatalog = ProductItems()
                                   .Where(x => x.SubCategory == subcategory || x.SubCategory == null)
                                   .OrderBy(x => x.ID)
                                   .Skip((page - 1) * PageSize)
                                   .Take(PageSize)

            }; 

            return View(productsList);
        }
        /*
        public FileContentResult GetImage(int productID)
        {
            var prodPhoto = productPhotoRepo.GetList().Where(p => p.ProductID == productID);
            var photo = (
                        from p in prodPhoto
                        join l in photoRepo.GetList() on p.ProductPhotoID equals l.ProductPhotoID
                        select new 
                        {
                            Data = l.ThumbNailPhoto,
                            Type = l.ThumbnailPhotoFileName
                        }
                ).ToList();


            if (photo != null)
            {
                return File(photo, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        */
        private IEnumerable<ProductCatalog> ProductItems()
        {
            var check = productRepo.GetList();
            AWContext context = new AWContext();
            var check2 = context.Product;

            var productCatalog = (
                                    from p in productRepo.GetList()
                                    join pri in inventoryRepo.GetList() on p.ProductID equals pri.ProductID
                                    join prl in locationRepo.GetList() on pri.LocationID equals prl.LocationID
                                    join prprph in productPhotoRepo.GetList() on p.ProductID equals prprph.ProductID
                                    join prph in photoRepo.GetList() on prprph.ProductPhotoID equals prph.ProductPhotoID
                                    join prm in modelRepo.GetList() on p.ProductModelID equals prm.ProductModelID
                                    join prmprd in modelDescriptionRepo.GetList() on prm.ProductModelID equals prmprd.ProductModelID
                                    join prd in descriptionRepo.GetList() on prmprd.ProductDescriptionID equals prd.ProductDescriptionID
                                    join prsc in productSubCategoryRepo.GetList() on p.ProductSubcategoryID equals prsc.ProductSubcategoryID
                                    join prc in productCategoryRepo.GetList() on prsc.ProductCategoryID equals prc.ProductCategoryID
                                    where prmprd.CultureID.Contains("en") && pri.Quantity > 0
                                    select new ProductCatalog
                                    {
                                        ID = p.ProductID,
                                        Name = p.Name,
                                        Color = p.Color,
                                        Description = prd.Description,
                                        Quantity = pri.Quantity,
                                        Location = prl.Name,
                                        Photo = prph.ThumbNailPhoto,
                                        SubCategory = prsc.Name,
                                        Price = p.ListPrice
                                    }
                );
            return productCatalog;
        }




    }
}