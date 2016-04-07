using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication5.Controllers
{
    class MyController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        protected override IActionInvoker CreateActionInvoker()
        {
            return base.CreateActionInvoker();
        }
    }
}
