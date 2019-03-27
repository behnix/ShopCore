using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.Product
{
    public class ConfigGroup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        public string Name { get; set; }

        [Display(Name = "عنوان فارسی")]
        public string Title { get; set; }

        public int Order { get; set; }

        public int CategoryId { get; set; }
    }
}
