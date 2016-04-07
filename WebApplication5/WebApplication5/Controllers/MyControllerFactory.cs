using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebApplication5.Controllers
{
    class MyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
