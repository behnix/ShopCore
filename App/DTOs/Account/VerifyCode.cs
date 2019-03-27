using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DTOs.Account
{
    public class VerifyCode
    {
        [Required]
        public string Code { get; set; }

        public string Provider { get; set; }

        public bool RememberMe { get; set; }

        public bool BrowserRemember { get; set; }

        public string ReturnTo { get; set; }
    }
}
