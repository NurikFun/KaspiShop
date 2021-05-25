using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using System;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace AW.Infrastructure.Business
{
    public class OrderProcessor : IOrderProcessor
    {

        public void ProcessOrder(ShopCartItem cart, ShoppingDetails shoppingDetails, int businessEntityID)
        {
            using (var scope = new TransactionScope())
            {
                InsertAddress(shoppingDetails, businessEntityID);
                int workerID = MinSalesWorker(shoppingDetails.City);
                InsertPurchaseOrderHeader(cart, workerID);
                scope.Complete();
            }
        }

        private int MinSalesWorker(string city)
        {
            using (var context = new AWContext())
            {
                var workerID = (from s in context.SalesPerson
                                join t in context.SalesTerritory on s.TerritoryID equals t.TerritoryID
                                join p in context.StateProvince on t.TerritoryID equals p.TerritoryID
                                where p.Name == city
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
                RevisionNumber = 1, Status = 1,
                EmployeeID = workerID, ShipMethodID = 1,
                OrderDate = DateTime.Now, SubTotal = totalPrice,
                TaxAmt = (totalPrice * 8) / 100, Freight = (totalPrice * 25) / 1000,
                TotalDue = totalPrice + (totalPrice * 8) / 100 + (totalPrice * 25) / 1000, ModifiedDate = DateTime.Now
            };
            foreach (var items in cart.Lines)
            {
                decimal subtotal = items.Product.ListPrice * items.Quantity;
                totalPrice += subtotal;
                orderDetails = new PurchaseOrderDetail
                {
                    DueDate = DateTime.Now.AddDays(3),  OrderQty = (short)items.Quantity,
                    ProductID = items.Product.ProductID, UnitPrice = items.Product.ListPrice,
                    LineTotal = subtotal, ReceivedQty = items.Quantity,
                    RejectedQty = 0, StockedQty = items.Quantity,
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

        private void InsertAddress(ShoppingDetails shoppingDetails, int businessEntityID)
        {
            ShoppingAddress shoppingAddress = new ShoppingAddress();
            ShoppingDetails details = shoppingAddress.Get(businessEntityID);
            if (!details.Equals(shoppingDetails))
            {
                var customerAddress = new Address()
                {
                    AddressLine1 = shoppingDetails.Address, City = shoppingDetails.City,
                    StateProvinceID = shoppingAddress.GetStateProvince(shoppingDetails.City, shoppingDetails.Country),
                    PostalCode = shoppingDetails.PostalCode, ModifiedDate = DateTime.Now,
                    rowguid = Guid.NewGuid()
                };
                var businessEntity = new BusinessEntityAddress()
                {
                    BusinessEntityID = businessEntityID, AddressTypeID = 1,
                    ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid()
                };
                using (var context = new AWContext())
                {
                    context.Address.Add(customerAddress);
                    context.SaveChanges();

                    businessEntity.AddressID = customerAddress.AddressID;
                    context.BusinessEntityAddress.Add(businessEntity);
                    context.SaveChanges();
                }
            }
        }

    }
}
