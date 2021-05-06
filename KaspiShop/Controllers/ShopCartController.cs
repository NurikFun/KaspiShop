using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using KaspiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IRepository<Product> productRepo;
        public ShopCartController(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public ActionResult Index(ShopCartItem cart, string returnUrl)
        {
            return View(new ShopCartItemViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(ShopCartItem cart, int productId, string locationName, string returnUrl)
        {
            Product product = productRepo.GetList()
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1, locationName);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(ShopCartItem cart, int productId, string locationName, string returnUrl)
        {
            Product product = productRepo.GetList()
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product, locationName);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(ShopCartItem cart)
        {
            return PartialView(cart);
        }


    }
}