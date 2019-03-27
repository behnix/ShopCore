using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.Product
{
    public class ConfigDetail
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ConfigChart ConfigChart { get; set; }

        public int ConfigChartId { get; set; }

        public string Value { get; set; }

        public int ConfigGroupId { get; set; }
    }
}
