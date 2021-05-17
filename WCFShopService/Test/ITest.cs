using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WCFShopService
{
    [ServiceContract]
    public interface ITest
    {
        [OperationContract]
        List<ProductCategoryTest> GetAllProducts();

    }

    [DataContract]
    public class ProductCategoryTest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<string> ProductSubcategories { get; set; }
    }

}