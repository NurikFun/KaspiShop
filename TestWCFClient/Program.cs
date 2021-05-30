using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {

            TestMQ.TestMQClient serviceClient = new TestMQ.TestMQClient();
            serviceClient.Process("awd");

            Console.ReadKey();
        }
    }
}
