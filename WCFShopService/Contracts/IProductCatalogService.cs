using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductCatalogService" in both code and config file together.
    [ServiceContract]
    public interface IProductCatalogService
    {
        [OperationContract]
        List<ProductCatalogDTO> GetList();
    }


    [DataContract]
    public class ProductCatalogDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string SubCategory { get; set; }
        [DataMember]
        public int PhotoID { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }

}
