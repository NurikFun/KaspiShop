using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Services.Interfaces;
using System.Collections.Generic;

namespace WCFShopService.Services
{
    public class OrderProcessorService : IOrderProcessorService
    {
        private IOrderProcessor orderProcessor;
        public OrderProcessorService(IOrderProcessor orderProcessor)
        {
            this.orderProcessor = orderProcessor;
        }

        public void ProcessOrder(List<ShopCartLineDTO> cart, ShoppingDetailsDTO shoppingDetails, int businessEntityID)
        {
            ShopCartItem shopCart = GetCartItem(cart);
            ShoppingDetails shopDetails = GetShoppingDetails(shoppingDetails);
            
            orderProcessor.ProcessOrder(shopCart, shopDetails, businessEntityID);
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
                }, item.Quantity, item.LocationName);
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
