using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SuzukiCompanion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class RoleService
    {
        public void CreateAdmin()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));


            if (!roleManager.RoleExists("Admin"))
            {

                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Student"))
            {
                roleManager.Create(new IdentityRole("Student"));
            }
        }
        public void MakeMyUserAdmin()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            var myUser = ctx.Users.SingleOrDefault(u => u.Email == "admin@suzukicompanion.com");
            if (myUser != null)
            {
                var adminRes = userManager.AddToRole(myUser.Id, "Admin");
            }
            //var userIsInRole = userManager.IsInRole(myUser.Id, "Student");
        }
       
    }
}
