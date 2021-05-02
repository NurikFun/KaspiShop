using AW.Domain.Core;
using AW.Domain.Interfaces;
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
        // GET: Product
        private readonly IRepository<Product> productRepo;
        public int PageSize = 4;
        public ProductController(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }


        public ActionResult List(string category, string subcategory, int page = 1)
        {
           /* ProductsListView productsList = new ProductsListView
            {
                CurrentCategory = category,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        productRepo.GetList()
                }
            }
           */

            return View();
        }
    }
}