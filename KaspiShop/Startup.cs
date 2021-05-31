using Microsoft.Owin;
using Owin;
using KaspiShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using AW.Infrastructure.Data;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(KaspiShop.Startup))]
namespace KaspiShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();

        }
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<Role, int>(new RoleStore<Role, int, UserRole>(context));
            var userManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>(context));
            userManager.UserValidator = new UserValidator<ApplicationUser, int>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            if (!roleManager.RoleExists("Employee"))
            {

                GeneratedDTO entities = new GeneratedDTO();

                var people = entities.Generate();
               
                var role = new Role();
                role.Name = "Employee";

                roleManager.Create(role);

                var user = new ApplicationUser();

                foreach (var person in people)
                {
                    user = new ApplicationUser
                    {
                        UserName = person.LoginID,
                        Email = person.LoginID,
                        BusinessEntityID = person.BusinessEntityID
                    };
                    var chkUser = userManager.Create(user, person.Password);

                    if (chkUser.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Employee");
                    }
                }

            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Role();
                role.Name = "Customer";

                roleManager.Create(role);
            }

        }

    }

    public class GeneratedDTO
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public int BusinessEntityID { get; set; }


        public List<GeneratedDTO> Generate()
        {
            using (var context = new AWContext())
            {
                var logins = (
                                from e in context.Employee
                                join s in context.SalesPerson on e.BusinessEntityID equals s.BusinessEntityID
                                join p in context.Person on e.BusinessEntityID equals p.BusinessEntityID
                                join pp in context.Password on p.BusinessEntityID equals pp.BusinessEntityID
                                select new GeneratedDTO
                                {
                                    LoginID = e.LoginID + "@gmail.com",
                                    Password = pp.PasswordSalt,
                                    BusinessEntityID = e.BusinessEntityID
                                }
                    );
            
                return logins.ToList();
            }
        } 

    }

}
