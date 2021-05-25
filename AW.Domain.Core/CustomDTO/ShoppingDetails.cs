using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Domain.Core.CustomDTO
{
    public class ShoppingDetails
    {

        [Required(ErrorMessage = "Please enter a region code")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "Line Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the postal code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is ShoppingDetails))
            {
                return false;
            }
            return (Country == ((ShoppingDetails)obj).Country)
                && (City == ((ShoppingDetails)obj).City)
                && (Address == ((ShoppingDetails)obj).Address)
                && (PostalCode == ((ShoppingDetails)obj).PostalCode);
        }
        public override int GetHashCode()
        {
            return Country.GetHashCode() ^ City.GetHashCode() ^ Address.GetHashCode() ^ PostalCode.GetHashCode();
        }

    }

}
