using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Services.Interfaces;
using KaspiShop.Models;
using KaspiShop.ProductService;
using KaspiShop.SalesTerritoryService;
using KaspiShop.ShopCartItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    [Authorize]
    public class ShopCartController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderProcessor orderRepo;
        private readonly ISalesTerritoryService salesService;
        private readonly IShopCartItemService shopCartItemService;
        private static List<string> Countries;
        public ShopCartController(IProductService productService, IOrderProcessor orderRepo,
            ISalesTerritoryService salesService, IShopCartItemService shopCartItemService)
        {
            this.productService = productService;
            this.orderRepo = orderRepo;
            this.salesService = salesService;
            this.shopCartItemService = shopCartItemService;
        }

        public ActionResult Index(ShopCartItemServiceClient check, string returnUrl)
        {
            return View(new ShopCartItemViewModel
            {
                ReturnUrl = returnUrl,
                Cart = check
            });
        }

        public RedirectToRouteResult AddToCart(ShopCartItemServiceClient check, int productId, string locationName, string returnUrl)
        {
            ProductService.ProductDTO product = productService.GetProduct(productId);
            ShopCartItemService.ProductDTO productDTO = new ShopCartItemService.ProductDTO() { 
                Name = product.Name,
                ProductID = product.ProductID,
                ListPrice = product.ListPrice
            };
            if (productDTO != null)
            {
                //shopCartItemService.AddItem(productDTO, 1, locationName);
                check.AddItem(productDTO, 1, locationName);

            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(ShopCartItemServiceClient check, int productId, string locationName, string returnUrl)
        {
            ProductService.ProductDTO product = productService.GetProduct(productId);
            ShopCartItemService.ProductDTO productDTO = new ShopCartItemService.ProductDTO()
            {
                Name = product.Name,
                ProductID = product.ProductID,
                ListPrice = product.ListPrice
            };

            if (productDTO != null)
            {
                check.RemoveLine(productDTO, locationName);
                
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(ShopCartItemServiceClient check)
        {
            return PartialView(check);
        }

        public ActionResult Checkout()
        {
            Countries = salesService.GetList().ToList();
            ViewBag.Country = Countries;
            return View(new ShoppingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShopCartItemServiceClient cart, ShoppingDetails shippingDetails)
        {
            if (cart.Lines().Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
             //   orderRepo.ProcessOrder(cart, shippingDetails);
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