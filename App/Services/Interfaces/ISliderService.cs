using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;
using App.Domain.Entities.Slider;
using Microsoft.AspNetCore.Http;

namespace App.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllSliders();

        Task<List<Slider>> GetAllActiveSliders();

        Task<Slider> GetSliderById(int? sliderId);

        Task<int> AddNewSlider(Slider slider, IFormFile sliderImageUp);

        void RemoveSliderAsync(int sliderId);
        
        Task UpdateSlider(Slider slider, IFormFile sliderImageUp, string oldImage);

        bool SliderExists(int sliderId);
        
        Task SaveChangeAsync();
    }
}
