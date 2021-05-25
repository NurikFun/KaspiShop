using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Services.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(ShopCartItem cart, ShoppingDetails shoppingDetails, int businessEntityID);
    }
}
