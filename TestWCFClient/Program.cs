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

            Test.ProductCatalogServiceClient product = new Test.ProductCatalogServiceClient();

            var values = product.GetList();

            foreach (var item in values)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
