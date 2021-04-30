using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Data.Repository.ModelRepository
{
    public class ProductProductPhotoRepository : Repository<ProductProductPhoto>
    {
        public ProductProductPhotoRepository(AWContext context) : base(context)
        {

        }
    }
}
