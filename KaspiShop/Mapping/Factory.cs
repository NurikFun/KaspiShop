using KaspiShop.ShopCartItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Mapping
{
    public class Factory
    {
        public IEnumerable<OrderProcessorService.ShopCartLineDTO> CreateCartLine(ShopCartLineDTO[] lineCart)
        {
            List<OrderProcessorService.ShopCartLineDTO> result = new List<OrderProcessorService.ShopCartLineDTO>();

            foreach (var item in lineCart)
            {
                result.Add(new OrderProcessorService.ShopCartLineDTO
                {
                    Quantity = item.Quantity,
                    ProductDTO = new OrderProcessorService.ProductDTO
                    {
                        ListPrice = item.ProductDTO.ListPrice,
                        Name = item.ProductDTO.Name,
                        ProductID = item.ProductDTO.ProductID
                    }
                });
            }
            return result;
        }


        public OrderProcessorService.ShoppingDetailsDTO CreateShoppingDetails(CustomerAddressService.ShoppingDetailsDTO shoppingDetails)
        {
            OrderProcessorService.ShoppingDetailsDTO result = new OrderProcessorService.ShoppingDetailsDTO()
            {
                Address = shoppingDetails.Address,
                City = shoppingDetails.City,
                PostalCode = shoppingDetails.PostalCode,
                Country = shoppingDetails.Country
            };
            return result;
        }

        public ProductDTO CreateProductDTO(ProductService.ProductDTO product)
        {
            ProductDTO result = new ProductDTO()
            {
                Name = product.Name,
                ProductID = product.ProductID,
                ListPrice = product.ListPrice
            };

            return result;
        }

    }
}