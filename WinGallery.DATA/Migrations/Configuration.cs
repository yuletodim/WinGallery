namespace WinGallery.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WinGallery.DATA.Common;
    using System.Threading.Tasks;
    using WinGallery.DATA.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WinGalleryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WinGallery.DATA.ApplicationDbContext";
        }

        protected override void Seed(WinGallery.DATA.WinGalleryContext context)
        {
            if (!context.Roles.Any())
            {
                this.SeedRoles();
            }

            if (!context.Users.Any())
            {
                this.SeedAdmin(context);
            }
        }

        private void SeedRoles()
        {
            var roles = new string[] 
            {
                DataConstants.AdminRole,
                DataConstants.ModeratorRole
            };

            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            Task.Run(async () =>
            {
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            })
            .GetAwaiter()
            .GetResult();
        }

        private void SeedAdmin(WinGalleryContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var adminUser = new User
            {
                Email = "admin@mysite.com",
                UserName = "Yulia",
                CreatedOn = DateTime.UtcNow,
                EmailConfirmed = true
            };

            Task.Run(async () =>
            {
                var result = await userManager.CreateAsync(adminUser, "123asD@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser.Id, DataConstants.AdminRole);
                }
            })
            .GetAwaiter()
            .GetResult();
        }
    }
}
