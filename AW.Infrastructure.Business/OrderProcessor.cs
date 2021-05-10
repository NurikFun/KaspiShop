using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Business
{
    public class OrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(ShopCartItem cart, ShoppingDetails shippingDetails)
        {
            throw new NotImplementedException();
        }
    }
}
