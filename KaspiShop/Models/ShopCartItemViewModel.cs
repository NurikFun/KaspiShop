using AW.Domain.Core;
using KaspiShop.ShopCartItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Models
{
    public class ShopCartItemViewModel
    {
        public ShopCartItemServiceClient Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}