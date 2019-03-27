using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities.Setting
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        [Display(Name = "عنوان سایت")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SiteName { get; set; }

        [Display(Name = "توضیحات سایت برای موتورهای جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteDescription { get; set; }

        [Display(Name = "تلفن های سایت")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteTel { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteAddress { get; set; }

        [Display(Name = "پست الکترونیکی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SiteEmail { get; set; }

        [Display(Name = "کلمه عبور ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteEmailPassword { get; set; }

        [Display(Name = "سرور SMTP")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteSmtp { get; set; }

        [Display(Name = "شماره فرستنده پیامک")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteSmsNumber { get; set; }

        [Display(Name = "کد احراز هویت پنل پیامکی")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteSmsSigniture { get; set; }

        [Display(Name = "حساب تلگرام")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteTelegramId { get; set; }

        [Display(Name = "حساب اینستاگرام")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteInstagramId { get; set; }

        [Display(Name = "حساب توییتر")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteTwitterId { get; set; }

        [Display(Name = "حساب فیسبوک")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteFacebookId { get; set; }

        [Display(Name = "متن کپی رایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string SiteCopyRightText { get; set; }

        [Display(Name = "محتوای درباره ما")]
        public string AboutUs { get; set; }

        [Display(Name = "محتوای صفحه اصلی")]
        public string Index { get; set; }
        
        [Display(Name = "شعار اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Slogan1 { get; set; }

        [Display(Name = "متن شعار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Slogan2 { get; set; }

        [Display(Name = "عنوان سرویس اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service1 { get; set; }

        [Display(Name = "آیکن سرویس اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Service1Icon { get; set; }
        
        [Display(Name = "شرح سرویس اول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service1Description { get; set; }

        [Display(Name = "عنوان سرویس دوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service2 { get; set; }

        [Display(Name = "آیکن سرویس دوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Service2Icon { get; set; }

        [Display(Name = "شرح سرویس دوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service2Description { get; set; }

        [Display(Name = "عنوان سرویس سوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service3 { get; set; }

        [Display(Name = "آیکن سرویس سوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Service3Icon { get; set; }

        [Display(Name = "شرح سرویس سوم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service3Description { get; set; }

        [Display(Name = "عنوان سرویس چهارم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service4 { get; set; }

        [Display(Name = "آیکن سرویس چهارم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Service4Icon { get; set; }

        [Display(Name = "شرح سرویس چهارم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Service4Description { get; set; }

        [Display(Name = "عنوان مروگر تماس با ما")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string ContactTitle { get; set; }

        [Display(Name = "توضیحات تماس با ما برای موتورهای جستجو")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string ContactDescription { get; set; }

        [Display(Name = "عنوان مروگر شرایط و مقررات")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string TermsTitle { get; set; }

        [Display(Name = "توضیحات تماس با ما برای موتورهای جستجو")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string TermsDescription { get; set; }

        [Display(Name = "شرایط و مقررات")]
        public string Terms { get; set; }

        [Display(Name = "ساعات کاری")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string ContactWorkHour { get; set; }

        [Display(Name = "عنوان مروگر سوالات متداول")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string FaqTitle { get; set; }

        [Display(Name = "توضیحات سوالات متداول برای موتورهای جستجو")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string FaqDescription { get; set; }

        [Display(Name = "عنوان مروگر درباره ما")]
        [MaxLength(65, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string AboutUsTitle { get; set; }

        [Display(Name = "متن صفحه سوالات متداول")]
        public string FaqText { get; set; }

        [Display(Name = "توضیحات درباره ما برای موتورهای جستجو")]
        [MinLength(120, ErrorMessage = "{0} نمیتواند کمتر از {1} حرف باشد.")]
        [MaxLength(155, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string AboutUsDescription { get; set; }

        [Display(Name = "آدرس سایت")]
        public string SiteNameInEnglish { get; set; }

        [Display(Name = "تعداد پست های صفحه اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int QuantityPostInIndex { get; set; }

        [Display(Name = "پورت ارتباط با سرور پست الکترونیکی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SmtpPort { get; set; }

        [Display(Name = "مرچنت آیدی درگاه اینترنتی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string MerchantId { get; set; }

        [Display(Name = "لوگوی سایت (187×52)")]
        public string Logo { get; set; }

        [Display(Name = "استایل سایت")]
        public string Style { get; set; }

    }
}
