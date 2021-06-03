using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFXMLService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void Process(string data);
    }

    [ServiceBehavior]
    public class Service : IService
    {
        [OperationBehavior]
        public void Process(string data)
        {
            Console.WriteLine(String.Format("Process data {0} at {1}", data, DateTime.Now));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(Service));

            host.Open();
            Console.WriteLine("Service is ready");
            Console.ReadLine();

        }
    }
}
