using AutoMapper;
using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Domain.Interfaces;
using AW.Infrastructure.Business;
using AW.Services.Interfaces;
using KaspiShop.CustomerAddressService;
using KaspiShop.Mapping;
using KaspiShop.Models;
using KaspiShop.OrderProcessorService;
using KaspiShop.ProductService;
using KaspiShop.SalesTerritoryService;
using KaspiShop.ShopCartItemService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KaspiShop.Controllers
{
    [Authorize]
    public class ShopCartController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderProcessorService orderService;
        private readonly ISalesTerritoryService salesService;
        private readonly IShopCartItemService shopCartItemService;
        private readonly ICustomerAddressService addressService;
        private static List<string> Countries;
        public ShopCartController(IProductService productService, IOrderProcessorService orderService,
            ISalesTerritoryService salesService, IShopCartItemService shopCartItemService, ICustomerAddressService addressService)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.salesService = salesService;
            this.shopCartItemService = shopCartItemService;
            this.addressService = addressService;
        }

        public ActionResult Index(ShopCartItemServiceClient cart, string returnUrl)
        {
            return View(new ShopCartItemViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(ShopCartItemServiceClient cart, int productId, string locationName, string returnUrl)
        {
            Factory factory = new Factory();

            ProductService.ProductDTO product = productService.GetProduct(productId);
            var productDTO = factory.CreateProductDTO(product);

            if (productDTO != null)
            {
                cart.AddItem(productDTO, 1, locationName);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(ShopCartItemServiceClient cart, int productId, string locationName, string returnUrl)
        {
            Factory factory = new Factory();
            ProductService.ProductDTO product = productService.GetProduct(productId);
            var productDTO = factory.CreateProductDTO(product);


            if (productDTO != null)
            {
                cart.RemoveLine(productDTO, locationName);

            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(ShopCartItemServiceClient check)
        {
            return PartialView(check);
        }

        public ActionResult Checkout()
        {
            int id = HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID;

            var details = addressService.Get(id);
            Countries = salesService.GetList().ToList();
            ViewBag.Country = Countries;

            if (details.Address != null)
            {
                return View(details);
            }

            return View(new CustomerAddressService.ShoppingDetailsDTO());
        }

        [HttpPost]
        public ActionResult Checkout(ShopCartItemServiceClient cart, CustomerAddressService.ShoppingDetailsDTO shoppingDetails)
        {
            Factory factory = new Factory();
            if (cart.Lines().Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (addressService.GetStateProvince(shoppingDetails.City, shoppingDetails.Country) < 1)
            {
                ModelState.AddModelError("", "Incorrect City in country");
            }
            var cartLine = factory.CreateCartLine(cart.Lines());
            var details = factory.CreateShoppingDetails(shoppingDetails);

            if (ModelState.IsValid)
            {
                orderService.ProcessOrder(cartLine.ToArray(), details, HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID);

                cart.Clear();
                return View("Completed");
            }
            else
            {
                ViewBag.Country = Countries;
                return View(shoppingDetails);
            }
        }

    }
}