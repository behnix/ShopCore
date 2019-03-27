using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Services.Identity.Validators
{
    public class AppPasswordValidator : PasswordValidator<User>
    {
        public AppPasswordValidator(IdentityErrorDescriber errors = null) : base(errors)
        {
        }
    }
}
