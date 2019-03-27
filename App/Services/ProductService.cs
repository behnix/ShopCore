using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Core.Uploader;
using App.Data;
using App.Domain.Entities.Product;
using App.DTOs;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Brand).Include(p => p.Category).OrderByDescending(p => p.ProductId).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsInCategory(int categoryId)
        {
            var allProducts = await GetAllProducts();
            return allProducts.Where(p => p.CategoryId == categoryId).ToList();
        }

        public async Task<List<Product>> GetAllProductsInBrand(int brandId)
        {
            var allProducts = await GetAllProducts();
            return allProducts.Where(p => p.BrandId == brandId).ToList();
        }

        public async Task<List<Product>> GetNewProducts(int take)
        {
            var allProducts = await GetAllProducts();
            return allProducts.OrderByDescending(p => p.CreatedOn).Take(take).ToList();
        }

        public async Task<List<Product>> GetMostVisitedProducts(int take)
        {
            var allProducts = await GetAllProducts();
            return allProducts.OrderByDescending(p => p.Visit).Take(take).ToList();
        }

        public async Task<List<Product>> GetMostSalesProducts(int take)
        {
            var allProducts = await GetAllProducts();
            return allProducts.OrderByDescending(p => p.Sales).Take(take).ToList();
        }

        public async Task<List<Product>> GetMostFavoriteProducts(int take)
        {
            var allProducts = await GetAllProducts();
            return allProducts.OrderByDescending(p => p.Like).Take(take).ToList();
        }

        public async Task<List<Product>> GetOfferProducts()
        {
            var allProducts = await GetAllProducts();
            return allProducts.OrderByDescending(p => p.PricePromotion != 0).ToList();
        }

        public async Task<Product> GetProductById(int? productId)
        {
            var allProducts = await GetAllProducts();
            return allProducts.SingleOrDefault(p => p.ProductId == productId);
        }

        public async Task<Product> GetProductByMetaTitle(string metaTitle)
        {
            var allProducts = await GetAllProducts();
            return allProducts.SingleOrDefault(p => p.MetaTitle == metaTitle);
        }

        public async Task<Product> GetProductByShortUrl(string shortUrl)
        {
            var allProducts = await GetAllProducts();
            return allProducts.SingleOrDefault(p => p.ShortUrl == shortUrl);
        }

        public async Task<int> AddProduct(Product product, IFormFile productImageUp)
        {
            product.CreatedOn = DateTime.Now;
            product.Visit = 0;
            product.Sales = 0;
            product.Like = 0;
            product.MetaTitle = TextConvertor.ReplaceLetters(TextConvertor.FixingText(product.MetaTitle), ' ', '-');

            product.Image = productImageUp == null ? "no-image.png" : ImageTools.UploadImageNormal("no-image.png", productImageUp, "no-image.png", "wwwroot/assets/products/img", true, "wwwroot/assets/products/thumb", 240);


            await _context.Products.AddAsync(product);
            await SaveChangeAsync();
            await SetShortUrlToProduct(product.ProductId);
            return product.ProductId;
        }

        public void RemoveProductAsync(int productId)
        {
            var productSelect = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (productSelect != null) _context.Products.Remove(productSelect);
        }

        public async Task IncreaseVisit(int productId)
        {
            var product = await GetProductById(productId);
            product.Visit += 1;
            await UpdateNormal(product);
        }

        public async Task IncreaseSale(int productId)
        {
            var product = await GetProductById(productId);
            product.Sales += 1;
            await UpdateNormal(product);
        }

        public async Task IncreaseLike(int productId)
        {
            var product = await GetProductById(productId);
            product.Like += 1;
            await UpdateNormal(product);
        }

        public async Task UpdateProductAsync(Product product, IFormFile productImageUp, string oldImage)
        {
            product.CreatedOn = DateTime.Now;
            product.MetaTitle = TextConvertor.ReplaceLetters(TextConvertor.FixingText(product.MetaTitle), ' ', '-');
            product.Image = productImageUp == null ? oldImage : ImageTools.UploadImageNormal(oldImage, productImageUp, "no-image.png", "wwwroot/assets/products/img", true, "wwwroot/assets/products/thumb", 240);

            _context.Products.Attach(product).State = EntityState.Modified;
            await SaveChangeAsync();

        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.ProductId == productId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsProductMetaTitleInBrowserRepeated(string productMetaTitle)
        {
            return await _context.Products.AnyAsync(p => p.MetaTitle == productMetaTitle);
        }

        public async Task SetShortUrlToProduct(int productId)
        {
            var productForAddShortUrl = await GetProductById(productId);
            productForAddShortUrl.ShortUrl = Base36.Encode(productId);
            await UpdateNormal(productForAddShortUrl);
            await SaveChangeAsync();
        }

        public async Task UpdateNormal(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<MostProductsViewModel> GetAllMostProducts()
        {
            {
                var products = await _context.Products.ToListAsync();
                var mostProductViewModel = new MostProductsViewModel()
                {
                    MostVisitProducs = products.OrderByDescending(p => p.Visit).Take(8),
                    MostSalesProducs = products.OrderByDescending(p => p.Sales).Take(8),
                    MostNewProducs = products.OrderByDescending(p => p.CreatedOn).Take(8),
                };
                return mostProductViewModel;
            }
        }

        public Tuple<List<SearchProductViewModel>, int> SearchProduct(int pageId, string filter
            , string orderBy,
            int minPrice, int maxPrice, List<int> selectedCategory, List<int> selectedBrand, int take)
        {
            IQueryable<Product> result = _context.Products;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Title.Contains(filter) || c.MetaTitle.Contains(filter) || c.Model.Contains(filter));
            }

            switch (orderBy)
            {
                case "date":
                    {
                        result = result.OrderByDescending(c => c.CreatedOn);
                        break;
                    }
                case "visit":
                    {
                        result = result.OrderByDescending(c => c.Visit);
                        break;
                    }
                case "sale":
                    {
                        result = result.OrderByDescending(c => c.Sales);
                        break;
                    }
                case "lowPrice":
                    {
                        result = result.OrderBy(c => c.Price);
                        break;
                    }
                case "highPrice":
                    {
                        result = result.OrderByDescending(c => c.Price);
                        break;
                    }
            }

            if (minPrice > 0)
            {
                result = result.Where(c => c.Price > minPrice);
            }

            if (maxPrice > 0)
            {
                result = result.Where(c => c.Price < maxPrice);
            }


            if (selectedCategory != null && selectedCategory.Any())
            {
                var resultCatRang = new List<Product>();
                foreach (int categoryId in selectedCategory)
                {
                    resultCatRang.AddRange(result.Where(c => c.CategoryId == categoryId));
                }
                
                result = resultCatRang.AsQueryable();
            }
            if (selectedBrand != null && selectedBrand.Any())
            {
                var resultBraRang = new List<Product>();
                foreach (int brandId in selectedBrand)
                {
                    resultBraRang.AddRange(result.Where(c => c.BrandId == brandId));
                }

                result = resultBraRang.AsQueryable();
            }

            int skip = (pageId - 1) * take;

            int pageCount = result.Include(c => c.Category).Include(c => c.Brand).Select(c => new SearchProductViewModel()
            {
                ProductId = c.ProductId,
                Image = c.Image,
                Price = c.Price,
                Title = c.Title,
                MetaTitle = c.MetaTitle,
                Description = c.Description
            }).Count();

            var query = result.Include(c => c.Category).Include(c => c.Brand).Select(c => new SearchProductViewModel()
            {
                ProductId = c.ProductId,
                Image = c.Image,
                Price = c.Price,
                Title = c.Title,
                MetaTitle = c.MetaTitle,
                Description = c.Description
            }).Skip(skip).Take(take).ToList();

            var resultTuple = Tuple.Create(query, pageCount);
            return resultTuple;
        }
    }
}
