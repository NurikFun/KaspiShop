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

            ServiceReference1.TestClient product = new ServiceReference1.TestClient();

            var values = product.GetAllProducts();

            foreach (var item in values)
            {
                Console.WriteLine(item.Name);
                foreach (var check in item.ProductSubcategories)
                {
                    Console.WriteLine("                 " + check);
                }
            }

            Console.ReadKey();
        }
    }
}
