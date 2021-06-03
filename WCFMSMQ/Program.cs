using AW.Domain.Core;
using AW.Infrastructure.Data.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Messaging;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading;
using System.Transactions;


namespace WCFMSMQ
{
   
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(XMLService));
            host.Open();
            Console.WriteLine("Service is ready");
            Console.ReadLine();
        }
    }
}
