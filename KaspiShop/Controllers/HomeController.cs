using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository<ProductPhoto> productPhotoRepository;


        public HomeController(IRepository<ProductPhoto> productPhotoRepository)
        {
            this.productPhotoRepository = productPhotoRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ProductList()
        {       
            var items = productPhotoRepository.GetList();
            return View(items);
        }


    }
}