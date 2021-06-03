using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Messaging;
using System.Xml.Linq;

namespace WCFShopService.Services
{
    public class OrderProcessorService : IOrderProcessorService
    {
        private IOrderProcessor orderProcessor;
        private INotificationSender sender;
        public OrderProcessorService(IOrderProcessor orderProcessor, INotificationSender sender)
        {
            this.orderProcessor = orderProcessor;
            this.sender = sender;
        }

        public void MessageQueueProcess()
        {
            MessageQueue mq = new MessageQueue(".\\Private$\\shippingorder");
            Message[] msgs = mq.GetAllMessages();

            foreach (var msg in msgs)
            {
                msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                XDocument result = XDocument.Parse(msg.Body.ToString());

                var purchaseID = result.Root.Element("orderHeader").Element("purchaseId").Value;
                var email = result.Root.Element("personData").Element("email").Value;

                orderProcessor.UpdateStatus(Convert.ToInt32(purchaseID), workerID: 0, status: 4);
                sender.SendMessage(email, "Delivered to you, visit us again!");
            }
        }

        public void ProcessOrder(List<ShopCartLineDTO> cart, ShoppingDetailsDTO shoppingDetails, int businessEntityID, string email)
        {
            ShopCartItem shopCart = GetCartItem(cart);
            ShoppingDetails shopDetails = GetShoppingDetails(shoppingDetails);
            
            orderProcessor.ProcessOrder(shopCart, shopDetails, businessEntityID, email);
        }

        private ShopCartItem GetCartItem(List<ShopCartLineDTO> cart)
        {
            ShopCartItem shopCart = new ShopCartItem();

            foreach (var item in cart)
            {
                shopCart.AddItem(new Product
                {
                    Name = item.ProductDTO.Name,
                    ProductID = item.ProductDTO.ProductID,
                    ListPrice = item.ProductDTO.ListPrice
                }, item.Quantity);
            }
            return shopCart;
        }

        private ShoppingDetails GetShoppingDetails(ShoppingDetailsDTO details)
        {
            ShoppingDetails shoppingDetails = new ShoppingDetails { 
                Address = details.Address,
                City = details.City,
                Country = details.Country,
                PostalCode = details.PostalCode
            };

            return shoppingDetails;
        }
    }
}
