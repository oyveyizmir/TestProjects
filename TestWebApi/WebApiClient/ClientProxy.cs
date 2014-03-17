using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    class ClientProxy
    {
        public Product GetProductByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12345");
                //client.DefaultRequestHeaders.Accept.Clear();
                var header = new MediaTypeWithQualityHeaderValue("application/test+json");
                header.Parameters.Add(new NameValueHeaderValue("version", "2"));
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage msg = client.GetAsync("api/products?name=" + name).Result;
                //msg.EnsureSuccessStatusCode();
                Console.WriteLine(msg);
                Console.WriteLine(msg.Content.ReadAsStringAsync().Result);
                if (msg.IsSuccessStatusCode)
                {
                    var product = msg.Content.ReadAsAsync<Product>().Result;
                    //var products = await msg.Content.ReadAsAsync<Product[]>();
                    //Array.ForEach(product, Console.WriteLine);
                    return product;
                }
                else
                {
                    Console.WriteLine("Error");
                    return null;
                }
            }
        }
    }
}
