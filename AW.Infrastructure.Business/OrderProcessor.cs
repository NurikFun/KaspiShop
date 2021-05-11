using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace AW.Infrastructure.Business
{
    public class OrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(ShopCartItem cart, ShoppingDetails shoppingDetails)
        {
            int workerID = MinSalesWorker(shoppingDetails.Country);
            InsertPurchaseOrderHeader(cart, workerID);
        }

        private int MinSalesWorker(string country)
        {
            using (var context = new AWContext())
            {
                var workerID = (from s in context.SalesPerson
                                join t in context.SalesTerritory on s.TerritoryID equals t.TerritoryID
                                where t.CountryRegionCode == country
                                orderby s.SalesLastYear
                                select s.BusinessEntityID
                            ).FirstOrDefault();
                return workerID;
            }
        }


        private void InsertPurchaseOrderHeader(ShopCartItem cart, int workerID)
        {
            decimal totalPrice = 0;
            PurchaseOrderDetail orderDetails = new PurchaseOrderDetail();
            var orderHeader = new PurchaseOrderHeader()
            {
                RevisionNumber = 1,
                Status = 1,
                EmployeeID = workerID,
                ShipMethodID = 1,
                OrderDate = DateTime.Now,
                SubTotal = totalPrice,
                TaxAmt = (totalPrice * 8) / 100,
                Freight = (totalPrice * 25) / 1000,
                TotalDue = totalPrice + (totalPrice * 8) / 100 + (totalPrice * 25) / 1000,
                ModifiedDate = DateTime.Now
            };
            foreach (var items in cart.Lines)
            {
                decimal subtotal = items.Product.ListPrice * items.Quantity;
                totalPrice += subtotal;
                orderDetails = new PurchaseOrderDetail
                {
                  
                    DueDate = DateTime.Now.AddDays(3),
                    OrderQty = (short)items.Quantity,
                    ProductID = items.Product.ProductID,
                    UnitPrice = items.Product.ListPrice,
                    LineTotal = subtotal,
                    ReceivedQty = items.Quantity,
                    RejectedQty = 0,
                    StockedQty = items.Quantity,
                    ModifiedDate = DateTime.Now
                };
                orderHeader.PurchaseOrderDetails.Add(orderDetails);
            }

            using (var context = new AWContext())
            {
                context.PurchaseOrderHeader.Add(orderHeader);
                context.SaveChanges();
            }

        }


    }
}
