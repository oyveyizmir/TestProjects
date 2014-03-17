using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiServer
{
    class ControllerSelector : IHttpControllerSelector
    {
        HttpConfiguration _conf;

        IDictionary<string, HttpControllerDescriptor> _descriptors = new Dictionary<string, HttpControllerDescriptor>();

        public ControllerSelector(HttpConfiguration conf)
        {
            _descriptors.Add("ProductsV1", new HttpControllerDescriptor(conf, "ProductsV1", typeof(ProductsController)));
            _descriptors.Add("ProductsV2", new HttpControllerDescriptor(conf, "ProductsV2", typeof(ProductsControllerV2)));
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _descriptors;
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();
            var controllerName = routeData.Values["controller"].ToString();

            if (controllerName != "products")
                return null;

            string version = GetVersion(request);
            switch(version)
            {
                case "1":
                case null:
                    return controllers["ProductsV1"];

                case "2":
                    return controllers["ProductsV2"];
            }

            return null;
        }

        static string GetVersion(HttpRequestMessage request)
        {
            var accept = request.Headers.Accept.FirstOrDefault(x => x.MediaType == "application/test+json");
            Console.WriteLine(accept);
            if (accept == null)
                return null;
            var param = accept.Parameters.FirstOrDefault(z => z.Name == "version");
            if (param == null)
                return null;

            return param.Value;
        }
    }
}
