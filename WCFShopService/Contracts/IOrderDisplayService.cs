using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderDisplayService" in both code and config file together.
    [ServiceContract]
    public interface IOrderDisplayService
    {
        [OperationContract]
        List<PurchaseOrderHeaderDTO> GetPurchaseOrders(int customerID);
        [OperationContract]
        List<ShopCartLineDTO> GetPurchaseOrderDetails(int purchaseID);
        [OperationContract]
        List<OrderDetailDTO> GetCustomerOrder(int employeeID);
    }

    [DataContract]
    public class BaseEntityDTO
    {
        [DataMember]
        public int PurchaseOrderID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal TotalDue { get; set; }
    }

    [DataContract]
    public class PurchaseOrderHeaderDTO : BaseEntityDTO
    {
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }

    }

    [DataContract]
    public class OrderDetailDTO : BaseEntityDTO
    {
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string AddressLine { get; set; }

    }

}
