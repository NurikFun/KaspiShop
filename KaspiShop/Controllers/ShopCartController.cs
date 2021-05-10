using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Services.Interfaces;
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
        private readonly IOrderProcessor orderRepo;
        private readonly IRepository<SalesTerritory> salesRepo;
        private static List<string> Countries;
        public ShopCartController(IRepository<Product> productRepo, IOrderProcessor orderRepo, 
            IRepository<SalesTerritory> salesRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.salesRepo = salesRepo;
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


        public ActionResult Checkout()
        {
            Countries = salesRepo.GetList().Select(x => x.CountryRegionCode).Distinct().ToList();
            ViewBag.Country = Countries;
            return View(new ShoppingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShopCartItem cart, ShoppingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderRepo.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                ViewBag.Country = Countries;
                return View(shippingDetails);
            }
        }

    }
}