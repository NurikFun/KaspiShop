using AW.Domain.Core;
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
    public class RegisterUser : IRegisterUser
    {
        public int Create(Person person)
        {
            using (var context = new AWContext())
            {
                BusinessEntity bs = new BusinessEntity {
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                context.BusinessEntity.Add(bs);
                context.SaveChanges();
                bs.Person = new Person
                {
                    BusinessEntityID = bs.BusinessEntityID,
                    PersonType = person.PersonType,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    ModifiedDate = DateTime.Now,
                    rowguid = Guid.NewGuid()
                };
                int id = bs.BusinessEntityID;
                context.SaveChanges();

                return id;
            }
        }
    }
}
