using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Services.Identity.Validators
{
    public class AppRoleValidator : RoleValidator<Role>
    {
    }
}
