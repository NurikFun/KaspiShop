using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {

             Proxy.XMLServiceClient service0 = new Proxy.XMLServiceClient();

             service0.CreateXML(4033, "nurik.iskakov.99@mail.ru");

            Order.OrderProcessorServiceClient service = new Order.OrderProcessorServiceClient();

            service.MessageQueueProcess();

            Console.WriteLine("All right");

            Console.ReadLine();
        } 
    }
}
