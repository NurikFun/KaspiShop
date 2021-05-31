using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Core.CustomDTO
{
    public class OrderDetail
    {
        public int PurchaseID { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDue { get; set; }
    }
}
