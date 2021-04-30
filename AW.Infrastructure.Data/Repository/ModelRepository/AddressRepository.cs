using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Data.Repository.ModelRepository
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(AWContext context) : base(context)
        {

        }
    }
}
