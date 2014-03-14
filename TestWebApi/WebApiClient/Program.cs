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
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12345");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage msg = await client.GetAsync("api/products?name=B");
                Console.WriteLine(msg);
                Console.WriteLine(await msg.Content.ReadAsStringAsync());
                if (msg.IsSuccessStatusCode)
                {
                    var product = await msg.Content.ReadAsAsync<Product>();
                    //var products = await msg.Content.ReadAsAsync<Product[]>();
                    //Array.ForEach(product, Console.WriteLine);
                    Console.WriteLine(product);
                }
                else
                    Console.WriteLine("Error");
            }
        }
    }
}
