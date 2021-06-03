using AW.Infrastructure.Business;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Xml.Linq;

namespace WCFMSMQ
{
    [ServiceBehavior]
    public class XMLService : IXMLService
    {
        private readonly XMLDoc repo;
        public XMLService()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            repo = kernel.Get<XMLDoc>();
        }

        [OperationBehavior]
        public void CreateXML(int purchaseID, string email)
        {
            var result = repo.Create(purchaseID, email).ToString();

            MessageQueue mq = new MessageQueue(".\\Private$\\shippingorder");
            if (MessageQueue.Exists(mq.Path) == false)
            {
                MessageQueue.Create(mq.Path);
            }
            else
            {
                mq = new MessageQueue(mq.Path);
            }
            mq.Send(result);
        }


    }
}
