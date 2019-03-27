using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.Product
{
    public class ConfigChart
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        public string Name { get; set; }

        [Display(Name = "عنوان فارسی")]
        public string Title { get; set; }

        public int Order { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ConfigGroup ConfigGroup { get; set; }

        public int ConfigGroupId { get; set; }

        [Display(Name = "نوع فیلتر")]
        public string FilterType { get; set; }

        [Display(Name = "توضیحات مشخصه")]
        public string ConfigDescription { get; set; }

        [Display(Name = "توضیحات تکمیلی")]
        public string ConfigDescriptionComplete { get; set; }
    }
}
