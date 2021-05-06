using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Interfaces
{
    public interface IProductCatalogRepository
    {
        IEnumerable<ProductCatalog> GetList();
    }
}
