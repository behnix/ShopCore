using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;
using App.DTOs;
using Microsoft.AspNetCore.Http;

namespace App.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();

        Task<List<Category>> GetAllParentCategories();

        Task<List<Category>> GetAllSubCategories();

        Task<List<Category>> GetCategoryByParentId(int categoryId);

        Task<Category> GetCategoryById(int? categoryId);

        Task<ParentCategoryWithNewProductsViewModel> GetAllParentCategoriesWithNewProducts();

        Task<int> AddNewCategory(Category category, IFormFile categoryImageUp, bool categoryParentId);

        Task RemoveCategoryAsync(Category category);

        Task UpdateCategory(Category category, IFormFile categoryImageUp, string oldImage);

        bool CategoryExists(int categoryId);
        
        Task SaveChangeAsync();
    }
}
