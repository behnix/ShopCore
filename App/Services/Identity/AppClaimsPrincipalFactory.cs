using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace App.Services.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public AppClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var claimIdentity = await base.GenerateClaimsAsync(user);
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer));
            claimIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            return claimIdentity;
        }
    }
}
