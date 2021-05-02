using AW.Domain.Core;
using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    public class NavController : Controller
    {
        private readonly IRepository<ProductCategory> productCategoryRepo;

        public NavController(IRepository<ProductCategory> productCategoryRepo)
        {
            this.productCategoryRepo = productCategoryRepo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<ProductCategory> categories = productCategoryRepo.GetList();

            return PartialView("FlexMenu", categories);
        }
    }
}