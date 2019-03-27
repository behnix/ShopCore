using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Entities.Product
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Name { get; set; }

        [Display(Name = "نام انگلیسی دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string EnName { get; set; }

        [Display(Name = "انتخاب دسته بندی")]
        public int ParentId { get; set; }

        [Display(Name = "تصویر دسته بندی")]
        public string CategoryImage { get; set; }
    }
}
