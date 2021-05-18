using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductCategoryService" in both code and config file together.
    [ServiceContract]
    public interface IProductCategoryService
    {
        [OperationContract]
        List<ProductCategoryDTO> GetList();
    }

    [DataContract]
    public class ProductCategoryDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<ProductSubcategoryDTO> SubCategories { get; set; }
    }

    [DataContract]
    public class ProductSubcategoryDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}
