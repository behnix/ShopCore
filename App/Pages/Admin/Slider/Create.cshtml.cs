using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Domain.Entities.Slider;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Slider
{
    public class CreateModel : PageModel
    {
        private readonly ISliderService _sliderService;

        public CreateModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Slider.Slider Slider { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile sliderImageUp, string startTime, string endTime)
        {
            Slider.SliderImage = sliderImageUp.ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Slider.SliderType == 2)
            {
                var startDate = startTime.Split("/");
                var endDate = endTime.Split("/");
                var ys = DateConvertor.PersianIntToEn(startDate[0]);
                var ms = DateConvertor.PersianIntToEn(startDate[1]);
                var ds = DateConvertor.PersianIntToEn(startDate[2]);
                var ye = DateConvertor.PersianIntToEn(endDate[0]);
                var me = DateConvertor.PersianIntToEn(endDate[1]);
                var de = DateConvertor.PersianIntToEn(endDate[2]);
                var startDateTime = new DateTime(ys, ms, ds).ToMiladiDate();
                var endDateTime = new DateTime(ye, me, de).ToMiladiDate();
                Slider.SliderStartTime = startDateTime;
                Slider.SliderEndTime = endDateTime;
            }
            await _sliderService.AddNewSlider(Slider, sliderImageUp);

            return RedirectToPage("./Index");
        }

        
    }
}