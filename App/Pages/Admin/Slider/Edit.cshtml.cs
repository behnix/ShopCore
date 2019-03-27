using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Slider;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace App.Pages.Admin.Slider
{
    public class EditModel : PageModel
    {

        private readonly ISliderService _sliderService;

        public EditModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [BindProperty]
        public Domain.Entities.Slider.Slider Slider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider = await _sliderService.GetSliderById(id);

            if (Slider == null)
            {
                return NotFound();
            }
            ViewData["SliderImage"] = Slider.SliderImage ?? "no-image.png";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile sliderImageUp, string oldImage, string startTime, string endTime)
        {
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

            try
            {
                await _sliderService.UpdateSlider(Slider, sliderImageUp, oldImage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(Slider.SliderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SliderExists(int id)
        {
            return _sliderService.SliderExists(id);
        }
    }
}
