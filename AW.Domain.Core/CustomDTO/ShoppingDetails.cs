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
        [Required(ErrorMessage = "Please enter a your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a region code")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "Line Address")]
        public string Address { get; set; }

    }

}
