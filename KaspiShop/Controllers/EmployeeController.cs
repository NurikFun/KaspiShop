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
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {

        private readonly IOrderDisplayService orderDisplay;
        public EmployeeController(IOrderDisplayService orderDisplay)
        {
            this.orderDisplay = orderDisplay;
        }
        // GET: Employee
        public ActionResult OrderHeader()
        {
            int id = HttpContext.GetOwinContext()
                  .GetUserManager<ApplicationUserManager>()
                  .FindById(Convert.ToInt32(User.Identity.GetUserId())).BusinessEntityID;

            var result = orderDisplay.GetCustomerOrder(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult OrderHeader(int purchaseID)
        {
            ViewBag.Temp = "OK";
            return View();
        }

    }
}