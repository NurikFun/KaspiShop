using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Infrastructure.Data;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace AW.Infrastructure.Business
{
    public class XMLDoc : IXMLUtility
    {
        public XDocument Create(int purchaseID, string email)
        {
            using (var scope = new TransactionScope())
            {
                var result = GetData(purchaseID);

                XDocument document = new XDocument(
                                        new XElement("order",
                                            new XElement("address",
                                                new XElement("city", result.OrderDetail.City),
                                                new XElement("addressLine", result.OrderDetail.AddressLine)),
                                            new XElement("personData",
                                                new XElement("firstName", result.FirstName),
                                                new XElement("lastName", result.LastName),
                                                new XElement("employeeID", result.EmployeeID),
                                                new XElement("email", email)),
                                            new XElement("orderHeader",
                                                new XElement("purchaseId", result.OrderDetail.PurchaseID),
                                                new XElement("totalDue", result.OrderDetail.TotalDue))
                                            )
                    );
                XElement details = new XElement("details");

                foreach (var value in result.OrderLine)
                {
                    details.Add(
                            new XElement("detail",
                                new XElement("id", value.PurchaseOrderDetailID),
                                new XElement("productName", value.ProductName),
                                new XElement("quantity", value.Quantity),
                                new XElement("lineTotal", value.LineTotal),
                                new XElement("unitPrice", value.UnitPrice)
                                )
                            );
                }
                document.Root.Add(details);
                INotificationSender sender = new MailSender();
                sender.SendMessage(email, "products are shipping for you!");
                scope.Complete();
                return document;
            }

        }

        private OrderXMLDetail GetData(int purchaseID)
        {
            using (AWContext context = new AWContext())
            {
                var result = (
                        from po in context.PurchaseOrderHeader
                        join be in context.BusinessEntity on po.BusinessEntityID equals be.BusinessEntityID
                        join per in context.Person on be.BusinessEntityID equals per.BusinessEntityID
                        join bea in context.BusinessEntityAddress on be.BusinessEntityID equals bea.BusinessEntityID
                        join ads in context.Address on bea.AddressID equals ads.AddressID
                        where po.PurchaseOrderID == purchaseID
                        select new OrderXMLDetail
                        {
                            OrderDetail = new OrderDetail
                            {
                                AddressLine = ads.AddressLine1,
                                City = ads.City,
                                PurchaseID = po.PurchaseOrderID,
                                TotalDue = po.TotalDue
                            },
                            EmployeeID = po.EmployeeID,
                            FirstName = per.FirstName,
                            LastName = per.LastName

                        }
                    ).FirstOrDefault();
                var subOrder = (
                        from pod in context.PurchaseOrderDetail
                        join p in context.Product on pod.ProductID equals p.ProductID
                        where pod.PurchaseOrderID == purchaseID
                        select new PurchaseOrderDetailXML
                        {
                            PurchaseOrderDetailID = pod.PurchaseOrderDetailID,
                            ProductName = p.Name,
                            Quantity = pod.OrderQty,
                            UnitPrice = pod.UnitPrice,
                            LineTotal = pod.LineTotal,
                            ProductID = pod.ProductID
                        }
                    );
                result.OrderLine = subOrder.ToList();
                UpdateOrder(result.OrderLine, purchaseID);
                return result;
            }
        }

        private void UpdateOrder(List<PurchaseOrderDetailXML> details, int purchaseID)
        {
            using (var context = new AWContext())
            {
                foreach (var detail in details)
                {
                    var result = context.ProductInventory.Where(x => x.ProductID == detail.ProductID).OrderByDescending(x => x.Quantity).FirstOrDefault();
                    result.Quantity -= detail.Quantity;
                }

                OrderProcessor order = new OrderProcessor();
                order.UpdateStatus(purchaseID, workerID: 0, status: 3);
                context.SaveChanges();
            }
        }

    }
}
