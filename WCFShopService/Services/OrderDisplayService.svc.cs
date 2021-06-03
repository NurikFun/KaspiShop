using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderDisplayService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderDisplayService.svc or OrderDisplayService.svc.cs at the Solution Explorer and start debugging.
    public class OrderDisplayService : IOrderDisplayService
    {
        private readonly IOrderDisplay orderRepo;
        public OrderDisplayService(IOrderDisplay orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public List<PurchaseOrderHeaderDTO> GetPurchaseOrders(int customerID)
        {
            var result = new List<PurchaseOrderHeaderDTO>();

            var details = orderRepo.GetPurchaseOrders(customerID);

            foreach (var detail in details)
            {
                result.Add(new PurchaseOrderHeaderDTO { 
                    Status = detail.Status,
                    ModifiedDate = detail.ModifiedDate,
                    SubTotal = detail.SubTotal,
                    TotalDue = detail.TotalDue,
                    PurchaseOrderID = detail.PurchaseOrderID
                });
            }

            return result;
        }


        public List<OrderDetailDTO> GetCustomerOrder(int employeeID)
        {
            var orders = orderRepo.GetCustomerOrder(employeeID);

            List<OrderDetailDTO> result = new List<OrderDetailDTO>();
            foreach (var order in orders)
            {
                result.Add(new OrderDetailDTO
                {
                    City = order.City,
                    AddressLine = order.AddressLine,
                    SubTotal = order.SubTotal,
                    TotalDue = order.TotalDue,
                    PurchaseOrderID = order.PurchaseID,
                    CustomerID = order.CustomerID
                });
            }

            return result;
        }

        public List<ShopCartLineDTO> GetPurchaseOrderDetails(int purchaseID)
        {
            var orders = orderRepo.GetPurchaseOrderDetails(purchaseID);

            List<ShopCartLineDTO> result = new List<ShopCartLineDTO>();

            foreach (var order in orders)
            {
                result.Add(new ShopCartLineDTO { 
                    ProductDTO = new ProductDTO
                    {
                        Name = order.Product.Name,
                        ListPrice = order.Product.ListPrice
                    },
                    Quantity = order.Quantity
                });
            }
            return result;
        }

    }
}
