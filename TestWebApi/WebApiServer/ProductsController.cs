using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiServer
{
    public class ProductsController : ApiController
    {
        Product[] _products = {
            new Product { Id = 1, Name = "A" },
            new Product{ Id = 2, Name = "B" }
        };

        public Product[] GetList()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetByName(string name)
        {
            return _products.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
