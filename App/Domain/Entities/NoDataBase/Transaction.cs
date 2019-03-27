using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.NoDataBase
{
    public class Transaction
    {
        public string Api { get; set; }
        
        [DisplayName("مبلغ پرداختی")]
        public string Amount { get; set; }
        
        public string Redirect { get; set; }
        
        public string FactorNumber { get; set; }
    }
}
