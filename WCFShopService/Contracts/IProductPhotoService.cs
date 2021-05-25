using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductPhotoService" in both code and config file together.
    [ServiceContract]
    public interface IProductPhotoService
    {
        [OperationContract]
        ProductPhotoDTO GetPhoto(int photoID);
    }

    [DataContract]
    public class ProductPhotoDTO
    {
        [DataMember]
        public int ProductPhotoID { get; set; }
        [DataMember]
        public byte[] ThumbNailPhoto { get; set; }

    }
}
