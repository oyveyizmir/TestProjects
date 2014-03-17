using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiServer
{
    class ProductsControllerV2 : ProductsController
    {
        public override Product GetByName(string name)
        {
            return GetList().Where(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}
