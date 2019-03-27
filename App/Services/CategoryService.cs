using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Uploader;
using App.Data;
using App.Domain.Entities.Product;
using App.DTOs;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetAllParentCategories()
        {
            return await _context.Categories.Where(c=>c.ParentId == 0).ToListAsync();
        }

        public async Task<List<Category>> GetAllSubCategories()
        {
            return await _context.Categories.Where(c => c.ParentId != 0).ToListAsync();
        }

        public async Task<ParentCategoryWithNewProductsViewModel> GetAllParentCategoriesWithNewProducts()
        {
            var categories = await GetAllParentCategories();
            var products = new List<Product>();
            foreach (var category in categories)
            {
                products.AddRange(await _context.Products.Include(p=>p.Category).Where(p=>p.Category.ParentId == category.Id).OrderByDescending(p=>p.CreatedOn).Take(8).ToListAsync());
            }
            var parentCategoryWithNewProductsViewModel = new ParentCategoryWithNewProductsViewModel()
            {
                Categories = await _context.Categories.Where(c => c.ParentId == 0).ToListAsync(),
                Products = products.OrderBy(p=>p.CreatedOn).ToList(),
            };
            return parentCategoryWithNewProductsViewModel;
        }

        public async Task<List<Category>> GetCategoryByParentId(int categoryId)
        {
            return await _context.Categories.Where(c => c.ParentId == categoryId).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int? categoryId)
        {
            return await _context.Categories.SingleOrDefaultAsync(b => b.Id == categoryId);
        }

        public async Task<int> AddNewCategory(Category category, IFormFile categoryImageUp, bool categoryParentId)
        {
            if (!categoryParentId)
            {
                category.CategoryImage = categoryImageUp == null ? "no-image.png" : ImageTools.UploadImageNormal("no-image.png", categoryImageUp, "no-image.png", "wwwroot/assets/categories/image", true, "wwwroot/assets/categories/thumb", 240);
                category.ParentId = 0;
            }

            _context.Categories.Add(category);
            await SaveChangeAsync();
            return category.Id;
        }

        public async Task RemoveCategoryAsync(Category category)
        {
            if (category.ParentId == 0)
            {
                var listOfChildCategory = await GetCategoryByParentId(category.Id);
                foreach (var cat in listOfChildCategory)
                {
                    if (cat != null) _context.Categories.Remove(cat);
                }
            }
            var categorySelect = _context.Categories.SingleOrDefault(b => b.Id == category.Id);
            if (categorySelect != null) _context.Categories.Remove(categorySelect);

            await SaveChangeAsync();
        }

        public async Task UpdateCategory(Category category, IFormFile categoryImageUp, string oldImage)
        {
            
            category.CategoryImage = categoryImageUp == null ? oldImage : ImageTools.UploadImageNormal(oldImage, categoryImageUp, "no-image.png", "wwwroot/assets/Categories/image", true, "wwwroot/assets/Categories/thumb", 240);

            _context.Categories.Attach(category).State = EntityState.Modified;
            await SaveChangeAsync();
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(b => b.Id == categoryId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
