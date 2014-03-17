using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(2000);
            GetByName(); ;
        }

        static void GetByName()
        {
            var client = new ClientProxy();
            Product product = client.GetProductByName("b");
            Console.WriteLine(product);
        }
    }
}
