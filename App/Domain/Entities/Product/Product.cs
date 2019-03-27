using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Enums;

namespace App.Domain.Entities.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "تصویر اصلی")]
        public string Image { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Title { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Description { get; set; }

        [Display(Name = "عنوان در مرورگر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string MetaTitle { get; set; }

        [Display(Name = "توضیحات برای موتورهای جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string MetaDescription { get; set; }

        [Display(Name = "مدل ")]
        public string Model { get; set; }

        public Brand Brand { get; set; }

        [Display(Name = "برند")]
        public int BrandId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "گارانتی")]
        public string Guarantee { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }

        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Display(Name = "قیمت ویژه")]
        public long PricePromotion { get; set; }

        [Display(Name = "قیمت همکار")]
        public long PriceCoworker { get; set; }

        public int Visit { get; set; }

        public int Like { get; set; }

        public int Sales { get; set; }

        public string ShortUrl { get; set; }

        public bool CommentOn { get; set; }

        public bool Published { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
