using AW.Domain.Core;
using AW.Domain.Interfaces;
using AW.Services.Interfaces;
using KaspiShop.OrderDisplayService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderDisplayService orderDisplay;
        public OrderController(IOrderDisplayService orderDisplay)
        {
            this.orderDisplay = orderDisplay;
        }

        public ActionResult PurchaseHeader()
        {
            int id = HttpContext.GetOwinContext()
              .GetUserManager<ApplicationUserManager>()
              .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID;

            var result = orderDisplay.GetPurchaseOrders(id);
            return View(result);
        }

        public ActionResult PurchaseDetail(int purchaseID)
        {
            var result = orderDisplay.GetPurchaseOrderDetails(purchaseID);

            return View(result);
        }
    }
}