using AW.Domain.Core;
using AW.Domain.Interfaces;
using KaspiShop.ProductCategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    [Authorize]
    public class NavController : Controller
    {
        private readonly IRepository<ProductCategory> productCategoryRepo;
        private readonly IProductCategoryService service;
        public NavController(IRepository<ProductCategory> productCategoryRepo, IProductCategoryService service)
        {
            this.productCategoryRepo = productCategoryRepo;
            this.service = service;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var value = service.GetList();
            return PartialView("FlexMenu", value);
        }
    }
}