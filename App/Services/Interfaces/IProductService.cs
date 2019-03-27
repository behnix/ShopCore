using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;
using App.DTOs;
using Microsoft.AspNetCore.Http;

namespace App.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetAllProductsInCategory(int categoryId);

        Task<List<Product>> GetAllProductsInBrand(int brandId);

        Task<List<Product>> GetNewProducts(int take);

        Task<List<Product>> GetMostVisitedProducts(int take);

        Task<List<Product>> GetMostSalesProducts(int take);

        Task<List<Product>> GetMostFavoriteProducts(int take);

        Task<List<Product>> GetOfferProducts();

        Task<Product> GetProductById(int? productId);

        Task<Product> GetProductByMetaTitle(string metaTitle);

        Task<Product> GetProductByShortUrl(string shortUrl);
        
        Task<int> AddProduct(Product product, IFormFile productImage);

        void RemoveProductAsync(int productId);

        Task IncreaseVisit(int productId);

        Task IncreaseSale(int productId);

        Task IncreaseLike(int productId);

        Task UpdateProductAsync(Product product, IFormFile productImage, string oldImage);

        bool ProductExists(int productId);

        Task SaveChangeAsync();
        
        Task<bool> IsProductMetaTitleInBrowserRepeated(string productMetaTitle);

        Task SetShortUrlToProduct(int productId);

        Task UpdateNormal(Product product);

        Task<MostProductsViewModel> GetAllMostProducts();

        Tuple<List<SearchProductViewModel>, int> SearchProduct(int pageId, string filter, string orderBy, int minPrice, int maxPrice,
            List<int> selectedCategory, List<int> selectedBrand, int take);
    }
}
