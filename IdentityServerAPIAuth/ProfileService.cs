using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServerAPIAuth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerAPIAuth
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        protected RoleManager<IdentityRole> _roleManager;

        public ProfileService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext requestContext)
        {
            var user = await _userManager.GetUserAsync(requestContext.Subject);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim("FullName", user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, String.Join(",", roles))
            };

            requestContext.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null) && user.IsActive;
        }
    }
}
