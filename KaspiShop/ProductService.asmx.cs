using AW.Domain.Core;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace KaspiShop
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> ProductList()
        {
            Repository<Product> repository = new Repository<Product>(new AWContext());
            var products = repository.GetList().Select(p => p.Name).ToList();
            return products;
        }


        [WebMethod]
        public string ProductByID(int id)
        {
            Repository<Product> repository = new Repository<Product>(new AWContext());
            string productName = repository.Get(id).Name;
            return productName;
        }
    }
}
