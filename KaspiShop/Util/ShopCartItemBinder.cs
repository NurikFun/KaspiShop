using AW.Domain.Core;
using KaspiShop.ShopCartItemService;
using System.Web.Mvc;

namespace KaspiShop.Util
{
    public class ShopCartItemBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {

            ShopCartItemServiceClient cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ShopCartItemServiceClient)controllerContext.HttpContext.Session[sessionKey];
            }
            if (cart == null)
            {
                cart = new ShopCartItemServiceClient();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}