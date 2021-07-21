using IdentityServerAPIAuth.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerAPIAuth.Persistence
{
    public class UserDataInitializer
    {
        public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            }
            if (!roleManager.RoleExistsAsync("GeneralUser").Result)
            {
                var result = roleManager.CreateAsync(new IdentityRole("GeneralUser")).Result;
            }
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("DevAdminUser").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "DevAdminUser",
                    UserName = "DevAdminUser",
                };

                var userCreationResult = userManager.CreateAsync(user, "devadmin@Password1").Result;

                if (userCreationResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("DevGeneralUser").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "DevGeneralUser",
                    UserName = "DevGeneralUser",
                };

                var userCreationResult = userManager.CreateAsync(user, "devgeneraluser@Password1").Result;

                if (userCreationResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "GeneralUser").Wait();
                }
            }
        }
    }
}
