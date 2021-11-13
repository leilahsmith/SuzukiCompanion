namespace SuzukiCompanion.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuzukiCompanion.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuzukiCompanion.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            var user = new ApplicationUser
            {
                Email = "xxx@example.com",
                UserName = "Owner",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, "secret");
            user.PasswordHash = hashed;
            var userStore = new UserStore<ApplicationUser>(context);
            userStore.CreateAsync(user).Wait();
            var userEntity = context.Users.First();

            context.SaveChanges();
            }
            



            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

