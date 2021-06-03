using KaspiShop.Models;
using KaspiShop.OrderDisplayService;
using KaspiShop.OrderProcessorService;
using KaspiShop.XMLService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaspiShop.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IOrderDisplayService orderDisplay;
        private readonly IXMLService xmlRepo;
        private readonly IOrderProcessorService orderProcessor;
        public EmployeeController(IOrderDisplayService orderDisplay, IXMLService xmlRepo, IOrderProcessorService orderProcessor)
        {
            this.orderDisplay = orderDisplay;
            this.xmlRepo = xmlRepo;
            this.orderProcessor = orderProcessor;
        }

        public ActionResult OrderHeader()
        {
            int id = HttpContext.GetOwinContext()
                  .GetUserManager<ApplicationUserManager>()
                  .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID;

            var result = orderDisplay.GetCustomerOrder(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult OrderHeader(int purchaseID, int customerID)
        {
            int id = HttpContext.GetOwinContext()
                  .GetUserManager<ApplicationUserManager>()
                  .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID;
            string email = HttpContext.GetOwinContext()
                  .GetUserManager<ApplicationUserManager>().Users.Where(x => x.BusinessEntityID == customerID).Select(a => a.Email).FirstOrDefault();


            xmlRepo.CreateXML(purchaseID, email);

            return RedirectToAction("OrderHeader");
        }

    }
}