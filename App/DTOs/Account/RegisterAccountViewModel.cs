using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App.DTOs.Account
{
    public class RegisterAccountViewModel
    {
        public RegisterAccountViewModel()
        {
            RegisteredOn = DateTime.Now;
        }

        [Required]
        [Display(Name = "نام کاربری")]
        [Remote("ValidateUserName", ErrorMessage = "نام کاربری انتخابی شما، قبلا ثبت شده است.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Remote("ValidateEmail", ErrorMessage = "ایمیل وارد شده قبلا ثبت شده است.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرا کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور های وارد شده همسان نمی باشند.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
