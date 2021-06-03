using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;

namespace WCFMSMQ
{
    [ServiceContract]
    public interface IXMLService
    {
        [OperationContract(IsOneWay = true)]
        void CreateXML(int purchaseID, string email);
    }
}
