using AW.Domain.Core.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Services.Interfaces
{
    public interface IShoppingAddress
    {
        ShoppingDetails Get(int businessEntityID);
        int GetStateProvince(string city, string country);
    }
}
