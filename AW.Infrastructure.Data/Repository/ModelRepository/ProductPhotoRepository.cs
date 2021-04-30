using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Data.Repository.ModelRepository
{
    public class ProductPhotoRepository : Repository<ProductPhoto>
    {
        public ProductPhotoRepository(AWContext context) : base(context)
        {

        }
    }
}
