using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var member = new User
                {
                    UserName = "member",
                    Email = "member@gmail.com"
                };

                await userManager.CreateAsync(member, "Pa$$w0rd");
                await userManager.AddToRoleAsync(member, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Admin", "Member"});
            }

            if (context.Managers.Any()) return;

            var managers = DbInitializerSeeds.GetManagers();

            context.Managers.AddRange(managers);

            context.SaveChanges();
        }
    }
}