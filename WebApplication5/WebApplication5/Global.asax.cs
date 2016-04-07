using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication5.Controllers;

namespace WebApplication5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory1));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public override void Init()
        {
            base.Init();

            //this.AddOnBeginRequestAsync(BeginHandler, EndHandler);
        }

        private void EndHandler(IAsyncResult ar)
        {
            ((Task)ar).Wait();
        }

        private IAsyncResult BeginHandler(object sender, EventArgs e, AsyncCallback cb, object extraData)
        {
            Debug.WriteLine("Begin request " + extraData);
            var task = Task.Factory.StartNew(() =>
            {
                Debug.WriteLine("Start");
                

                var t2 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(100);
                });
                t2.Wait();

                cb?.Invoke(t2);
                Debug.WriteLine("Stop");
            });
            
            return task;
        }
    }
}
