using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerAddressService" in both code and config file together.

    [ServiceContract]
    public interface ICustomerAddressService
    {
        [OperationContract]
        ShoppingDetailsDTO Get(int businessEntityID);
        [OperationContract]
        int GetStateProvince(string city, string countryCode);
    }

    [DataContract]
    public class ShoppingDetailsDTO
    {
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
    }
}
