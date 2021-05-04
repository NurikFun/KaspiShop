using AW.Infrastructure.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Models
{
    public class ShopCartItemViewModel
    {
        public ShopCartItem Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}