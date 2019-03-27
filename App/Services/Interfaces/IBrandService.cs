using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;
using Microsoft.AspNetCore.Http;

namespace App.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrands();

        Task<Brand> GetBrandById(int? brandId);

        Task<int> AddNewBrand(Brand brand, IFormFile brandImageUp);

        void RemoveBrandAsync(int brandId);
        
        Task UpdateBrand(Brand brand, IFormFile brandImageUp, string oldImage);

        bool BrandExists(int brandId);
        
        Task SaveChangeAsync();
    }
}
