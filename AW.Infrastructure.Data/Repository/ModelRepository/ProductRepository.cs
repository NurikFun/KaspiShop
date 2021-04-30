using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Data.Repository.ModelRepository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AWContext context) : base(context)
        {

        }
    }
}
