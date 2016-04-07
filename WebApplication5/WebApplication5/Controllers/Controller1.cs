using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication5.Controllers
{
    public class Controller1 : Controller
    {
        protected override void Execute(RequestContext requestContext)
        {
            Debug.WriteLine("Controller.Execute " + requestContext.HttpContext.Request.Url);

            base.Execute(requestContext);
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}