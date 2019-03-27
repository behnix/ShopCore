using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.NoDataBase
{
    public class VerifyResult
    {
        public bool Success { get; set; }

        public string TransActionId { get; set; }

        public string Amount { get; set; }

        public string SuccessMessage { get; set; }

        public bool Error { get; set; }

        public string ErrorMessage { get; set; }
    }
}
