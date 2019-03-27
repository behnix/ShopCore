using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Uploader;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;

        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandById(int? brandId)
        {
            return await _context.Brands.SingleOrDefaultAsync(b => b.Id == brandId);
        }

        public async Task<int> AddNewBrand(Brand brand, IFormFile brandImageUp)
        {
            brand.Logo = brandImageUp == null ? "no-image.png" : ImageTools.UploadImageNormal("no-image.png", brandImageUp, "no-image.png", "wwwroot/assets/brands", false, "wwwroot/assets/brands", 240);

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }

        public void RemoveBrandAsync(int brandId)
        {
            var brandSelect = _context.Brands.SingleOrDefault(b => b.Id == brandId);
            if (brandSelect != null) _context.Brands.Remove(brandSelect);
        }

        public async Task UpdateBrand(Brand brand, IFormFile brandImageUp, string oldImage)
        {
            brand.Logo = brandImageUp == null ? oldImage : ImageTools.UploadImageNormal(oldImage, brandImageUp, "no-image.png", "wwwroot/assets/brands", false, "wwwroot/assets/brands", 240);

            _context.Brands.Update(brand);
            await SaveChangeAsync();
        }

        public bool BrandExists(int brandId)
        {
            return _context.Brands.Any(b => b.Id == brandId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
