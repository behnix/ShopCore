using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DTOs.Account
{
    public class LoginAccountViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
