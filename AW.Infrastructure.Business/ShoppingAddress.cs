using AW.Domain.Core;
using AW.Domain.Core.CustomDTO;
using AW.Infrastructure.Data;
using AW.Infrastructure.Data.Repository;
using AW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Infrastructure.Business
{
    public class ShoppingAddress : IShoppingAddress
    {

        public ShoppingDetails Get(int businessEntityID)
        {
            ShoppingDetails details = new ShoppingDetails();

            using (var context = new AWContext())
            {
                var result = (from a in context.Address
                              join b in context.BusinessEntityAddress on a.AddressID equals b.AddressID
                              join sp in context.StateProvince on a.StateProvinceID equals sp.StateProvinceID
                              where b.BusinessEntityID == businessEntityID
                              orderby a.AddressID descending
                              select new
                              {
                                  AddressLine1 = a.AddressLine1,
                                  City = a.City,
                                  PostalCode = a.PostalCode,
                                  CountryRegionCode = sp.CountryRegionCode
                              }
                    ).FirstOrDefault();

                if (result != null)
                    details = new ShoppingDetails
                    {
                        Address = result.AddressLine1,
                        City = result.City,
                        PostalCode = result.PostalCode,
                        Country = result.CountryRegionCode
                    };
            }
            return details;
        }

        public int GetStateProvince(string city, string countryCode)
        {
            using (var context = new AWContext())
            {
                int result = (
                         from s in context.StateProvince
                         where s.Name == city && s.CountryRegionCode == countryCode
                         select s.StateProvinceID
                    ).FirstOrDefault();

                return result;
            }
        }
    }
}
