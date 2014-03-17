using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace WebApiServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new HttpSelfHostConfiguration("http://localhost:12345");
            conf.Routes.MapHttpRoute("API default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            conf.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector(conf));

            using(var server = new HttpSelfHostServer(conf))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Started");
                Console.ReadLine();
            }
        }
    }
}
