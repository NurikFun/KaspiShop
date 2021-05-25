using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerAddressService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerAddressService.svc or CustomerAddressService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerAddressService : ICustomerAddressService
    {
        private IShoppingAddress shoppingAddress;

        public CustomerAddressService(IShoppingAddress shoppingAddress)
        {
            this.shoppingAddress = shoppingAddress;
        }

        public ShoppingDetailsDTO Get(int businessEntityID)
        {
            var values = shoppingAddress.Get(businessEntityID);
            ShoppingDetailsDTO result = new ShoppingDetailsDTO
            {
                Country = values.Country,
                City = values.City,
                Address = values.Address,
                PostalCode = values.PostalCode
            };
            return result;
        }

        public int GetStateProvince(string city, string countryCode)
        {
            int result = shoppingAddress.GetStateProvince(city, countryCode);
            return result;
        }
    }

}
