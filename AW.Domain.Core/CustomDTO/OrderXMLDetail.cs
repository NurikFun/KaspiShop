using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Core.CustomDTO
{
    public class OrderXMLDetail
    {
        public OrderDetail OrderDetail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
        public List<PurchaseOrderDetailXML> OrderLine { get; set; }
    }

    public class PurchaseOrderDetailXML
    {
        public int PurchaseOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public decimal LineTotal { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
