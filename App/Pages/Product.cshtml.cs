using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IConfigGroupService _configGroupService;
        private readonly IConfigChartService _configChartService;
        private readonly IConfigDetailService _configDetailService;
        private readonly ICommentService _commentService;

        public ProductModel(IProductService productService, IConfigGroupService configGroupService, IConfigChartService configChartService, IConfigDetailService configDetailService, ICommentService commentService)
        {
            _productService = productService;
            _configGroupService = configGroupService;
            _configChartService = configChartService;
            _configDetailService = configDetailService;
            _commentService = commentService;
        }


        public Product Product { get; set; }
        public IEnumerable<ConfigGroup> ConfigGroups { get; set; }
        public IEnumerable<ConfigChart> ConfigCharts { get; set; }
        public IEnumerable<ConfigDetail> ConfigDetails { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public async Task<IActionResult> OnGetAsync(string metaTitle, bool sentMessage = false)
        {
            if (metaTitle == null)
            {
                return NotFound();
            }

            if (sentMessage)
            {
                ViewData["Message"] = "دیدگاه شما با موفقیت ارسال و پس از تائید نمایش داده خواهد شد.";
            }
            Product = await _productService.GetProductByMetaTitle(metaTitle);
            Comments = await _commentService.GetAllCommentsByProductId(Product.ProductId);
            ConfigGroups = await _configGroupService.GetAllConfigGroupByCategoryId(Product.CategoryId);
            ConfigCharts = await _configChartService.GetAllConfigChartByCategoryId(Product.CategoryId);
            ConfigDetails = await _configDetailService.GetAllConfigDetailsByProductId(Product.ProductId);

            if (Product == null)
            {
                return NotFound();
            }
            await _productService.IncreaseVisit(Product.ProductId);
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }
        public async Task<IActionResult> OnPostAsync(string userName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _commentService.AddComment(Comment, userName);
            var product = await _productService.GetProductById(Comment.ProductId);
            ViewData["Message"] = "دیدگاه شما با موفقیت ارسال و پس از تائید نمایش داده خواهد شد.";
            return RedirectToPage("/product", new {metaTitle = product.MetaTitle, sentMessage = true});
        }
    }
}
