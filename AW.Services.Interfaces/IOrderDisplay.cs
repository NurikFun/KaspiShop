using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Services.Interfaces
{
    public interface IOrderDisplay
    {
        List<PurchaseOrderHeader> GetPurchaseOrders(int businessEntityID);
        List<ShopCartLine> GetPurchaseOrderDetails(int purchaseID);
    }
}
