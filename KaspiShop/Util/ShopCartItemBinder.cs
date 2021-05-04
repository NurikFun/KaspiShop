using AW.Infrastructure.Business;
using System.Web.Mvc;

namespace KaspiShop.Util
{
    public class ShopCartItemBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {

            ShopCartItem cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ShopCartItem)controllerContext.HttpContext.Session[sessionKey];
            }
            if (cart == null)
            {
                cart = new ShopCartItem();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}