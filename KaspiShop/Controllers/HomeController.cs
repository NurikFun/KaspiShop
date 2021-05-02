using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using KaspiShop.Models;
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
        private readonly IRepository<Product> productRepository;

        public HomeController(IRepository<ProductPhoto> productPhotoRepository, IRepository<Product> productRepository)
        {
            this.productPhotoRepository = productPhotoRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult ProductList()
        {       
            var items = productPhotoRepository.GetList();
            return View(items);
        }

    }
}