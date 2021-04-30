using AW.Domain.Interfaces;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using AW.Infrastructure.Data.Repository.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<ProductRepository> productRepository;
        private readonly IRepository<ProductProductPhotoRepository> productProductPhotoRepository;
        private readonly IRepository<ProductPhotoRepository> productPhotoRepository;

        public HomeController(IRepository<ProductRepository> productRepository, IRepository<ProductProductPhotoRepository> productProductPhotoRepository,
            IRepository<ProductPhotoRepository> productPhotoRepository)
        {
            this.productRepository = productRepository;
            this.productPhotoRepository = productPhotoRepository;
            this.productProductPhotoRepository = productProductPhotoRepository;
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
           // ProductPhotoRepository photoRepository = new ProductPhotoRepository(new AWContext());
       
            var items = productPhotoRepository.GetList();
           // var items = photoRepository.GetList();
            return View(items);
        }


    }
}