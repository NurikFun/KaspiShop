using AW.Domain.Core;
using AW.Domain.Interfaces;
using KaspiShop.TestService;
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
        private readonly ITest testService;
        public NavController(IRepository<ProductCategory> productCategoryRepo, ITest testService)
        {
            this.productCategoryRepo = productCategoryRepo;
            this.testService = testService;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var value = testService.GetAllProducts();
          //  IEnumerable<ProductCategory> categories = productCategoryRepo.GetList();

            return PartialView("FlexMenu", value);
        }
    }
}