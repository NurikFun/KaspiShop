using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    [ServiceContract]
    public interface IShopCartItemService
    {
        [OperationContract]
        void AddItem(ProductDTO product, int quantity, string locationName);
        [OperationContract]
        void RemoveLine(ProductDTO product, string locationName);
        [OperationContract]
        decimal ComputeTotalValue();
        [OperationContract]
        void Clear();
        [OperationContract]
        IEnumerable<ShopCartLineDTO> Lines();
    }

    [DataContract]
    public class ShopCartLineDTO
    {
        [DataMember]
        public ProductDTO ProductDTO { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string LocationName { get; set; }
    }
}
