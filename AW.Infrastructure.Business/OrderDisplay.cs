using AW.Domain.Core;
using AW.Infrastructure.Data;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Business
{
    public class OrderDisplay : IOrderDisplay
    {
        public List<PurchaseOrderHeader> GetPurchaseOrders(int businessEntityID)
        {
            using (AWContext context = new AWContext())
            {
                var result = (
                        from h in context.PurchaseOrderHeader
                        where (h.Status == 2 || h.Status == 3) && h.BusinessEntityID == businessEntityID
                        select h
                    );
                return result.ToList();
            }
        }

        public List<ShopCartLine> GetPurchaseOrderDetails(int purchaseID)
        {
            var result = new List<ShopCartLine>();
            using (AWContext context = new AWContext())
            {
                var items = (
                        from pod in context.PurchaseOrderDetail
                        join p in context.Product on pod.ProductID equals p.ProductID
                        where pod.PurchaseOrderID == purchaseID
                        select new
                        {
                            Product = pod.Product,
                            Quantity = pod.OrderQty
                        }
                    );
                foreach (var item in items)
                {
                    result.Add(new ShopCartLine
                    {
                        Product = item.Product,
                        Quantity = item.Quantity
                    });
                }
                return result;
            }

        }

    }
}
