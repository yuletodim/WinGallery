namespace WinGallery.DATA.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<WinGallery.DATA.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WinGallery.DATA.ApplicationDbContext";
        }

        protected override void Seed(WinGallery.DATA.ApplicationDbContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            if (!context.Roles.Any())
            {
                const string GuestRole = "Guest";
                const string UserRole = "User";
                const string ModeratorRole = "Moderator";
                const string AdminRole = "Admin";

                var roleStore = new RoleStore<IdentityRole>();
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Create(new IdentityRole(GuestRole));
                roleManager.Create(new IdentityRole(UserRole));
                roleManager.Create(new IdentityRole(ModeratorRole));
                roleManager.Create(new IdentityRole(AdminRole));
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
