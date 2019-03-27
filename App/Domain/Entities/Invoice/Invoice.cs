using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.Invoice
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FactoredOn { get; set; }

        public int UserId { get; set; }

        public string CostumerName { get; set; }

        public string CostumerEmail { get; set; }

        public string CostumerPhone { get; set; }

        public string CostumerAddress { get; set; }

        public string NationCode { get; set; }

        public string EconomyCode { get; set; }

        public string ZipCode { get; set; }

        public bool IsOfficial { get; set; }

        public string State { get; set; }

        public string StateCode { get; set; }

        public string RefNum { get; set; }

        public string CId { get; set; }

        public string TransactionNo { get; set; }

        public string SecurePan { get; set; }

        public string MessageSent { get; set; }

        public bool Purchased { get; set; }

        public bool Transported { get; set; }

        public string SessionId { get; set; }

        public long Amount { get; set; }
    }
}
