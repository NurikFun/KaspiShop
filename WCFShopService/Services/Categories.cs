using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFShopService.Services
{
    [ServiceContract]
    public interface Categories
    {
        //[OperationContract]
        //public List<>
    }

    [DataContract]
    public class ProductCategory
    {
        [DataMember]
        public string Name { get; set; }

    }

}
