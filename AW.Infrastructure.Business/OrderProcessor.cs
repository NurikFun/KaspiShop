using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using System;
using System.Transactions;
using System.Linq;


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
                int orderID = InsertPurchaseOrderHeader(cart, businessEntityID, shoppingDetails.Country);
                UpdateStatus(orderID, workerID);
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

        private int InsertPurchaseOrderHeader(ShopCartItem cart, int businessEntityID, string country)
        {
            decimal totalPrice = 0;
            PurchaseOrderDetail orderDetails = new PurchaseOrderDetail();
            var orderHeader = new PurchaseOrderHeader()
            {
                RevisionNumber = 1, Status = 1,
                ShipMethodID = 1, OrderDate = DateTime.Now,
                ModifiedDate = DateTime.Now, BusinessEntityID = businessEntityID
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
            orderHeader.SubTotal = totalPrice;
            orderHeader.TaxAmt = GetTaxRate(country) / 100 * totalPrice;
            orderHeader.Freight = ShipBaseRate() / 100 * totalPrice;
            orderHeader.TotalDue = totalPrice + orderHeader.Freight + orderHeader.TaxAmt;

            using (var context = new AWContext())
            {
                context.PurchaseOrderHeader.Add(orderHeader);
                context.SaveChanges();
            }
            return orderHeader.PurchaseOrderID;
        }


        private void UpdateStatus(int orderID, int workerID, byte status = 2)
        {
            using (AWContext context = new AWContext())
            {
                var result = context.PurchaseOrderHeader.SingleOrDefault(o => o.PurchaseOrderID == orderID);
                result.EmployeeID = workerID;
                result.Status = status;
                context.SaveChanges();
            }
        }

        private decimal GetTaxRate(string country)
        {
            using (AWContext context = new AWContext())
            {
                var result = (from t in context.SalesTaxRate
                              join s in context.StateProvince on t.StateProvinceID equals s.StateProvinceID
                              where s.CountryRegionCode == country
                              select t.TaxRate
                    ).FirstOrDefault();
                return result;
            }
        }

        private decimal ShipBaseRate()
        {
            Repository<ShipMethod> repository = new Repository<ShipMethod>(new AWContext());
            var result = repository.Get(1).ShipBase;
            return result;
        }


        private void InsertAddress(ShoppingDetails shoppingDetails, int businessEntityID)
        {
            ShoppingAddress shoppingAddress = new ShoppingAddress();
            ShoppingDetails details = shoppingAddress.Get(businessEntityID);
            if (!details.Equals(shoppingDetails))
            {
                using (var context = new AWContext())
                {
                    var customerAddress = new Address()
                    {
                        AddressLine1 = shoppingDetails.Address, City = shoppingDetails.City,
                        StateProvinceID = shoppingAddress.GetStateProvince(shoppingDetails.City, shoppingDetails.Country),
                        PostalCode = shoppingDetails.PostalCode, ModifiedDate = DateTime.Now,
                        rowguid = Guid.NewGuid()
                    };
                    if (details.Address != null)
                    {
                        var addressID = context.BusinessEntityAddress.SingleOrDefault(x => x.BusinessEntityID == businessEntityID).AddressID;
                        var result = context.Address.SingleOrDefault(x => x.AddressID == addressID);
                        result.AddressLine1 = customerAddress.AddressLine1;
                        result.City = customerAddress.City;
                        result.StateProvinceID = customerAddress.StateProvinceID;
                        result.PostalCode = customerAddress.PostalCode;
                        result.ModifiedDate = customerAddress.ModifiedDate;
                        result.rowguid = customerAddress.rowguid;
                        context.SaveChanges();
                        //update 
                    }
                    else
                    {
                        var businessEntity = new BusinessEntityAddress()
                        {
                            BusinessEntityID = businessEntityID,
                            AddressTypeID = 1,
                            ModifiedDate = DateTime.Now,
                            rowguid = Guid.NewGuid()
                        };
                        context.Address.Add(customerAddress);
                        context.SaveChanges();

                        businessEntity.AddressID = customerAddress.AddressID;
                        context.BusinessEntityAddress.Add(businessEntity);
                        context.SaveChanges();
                        // insert
                    }
                }
                
            }
        }
    }
}
