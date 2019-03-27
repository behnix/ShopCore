using System;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        public Role Role { get; set; }

        public DateTime GivenOn { get; set; }
    }
}
