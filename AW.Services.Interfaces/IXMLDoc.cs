using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AW.Services.Interfaces
{
    public interface IXMLUtility
    {
        XDocument Create(int purchaseID, string email); 

    }
}
