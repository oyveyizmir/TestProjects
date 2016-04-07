using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication5.App_Code
{
    public class Module1 : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
        }

        private void Context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;
            Debug.WriteLine("Request " + context.Request.Url);
        }
    }
}
