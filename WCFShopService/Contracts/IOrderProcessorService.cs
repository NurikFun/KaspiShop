using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    [ServiceContract]
    public interface IOrderProcessorService
    {
        [OperationContract]
        void ProcessOrder(List<ShopCartLineDTO> cart, ShoppingDetailsDTO shoppingDetails, int businessEntityID);
    }

}
