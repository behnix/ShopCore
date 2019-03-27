using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Services.Identity.Validators
{
    public class AppUserValidator : UserValidator<User>
    {
        public AppUserValidator(IdentityErrorDescriber errors) :base(errors)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            var result = await base.ValidateAsync(manager, user);
            ValidateEmail(user,result.Errors.ToList());
            return result;
        }

        private static void ValidateEmail(User user, ICollection<IdentityError> errors)
        {
            if (user.UserName.Contains("admin"))
            {
                errors.Add(new IdentityError()
                {
                    Code = "Invalid UserName",
                    Description = "شما نمیتوانید در نام کاربری خود از عبارت admin استفاده نمائید."
                });
            }
        }
    }
}
