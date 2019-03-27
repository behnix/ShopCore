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

namespace App.Pages.Admin.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;

        public IndexModel(ICommentService commentService, IProductService productService)
        {
            _commentService = commentService;
            _productService = productService;
        }

        public IList<Domain.Entities.Product.Comment> Comment { get;set; }
        public Domain.Entities.Product.Product Product { get; set; }
        public async Task OnGetAsync(int productId)
        {
            Product = await _productService.GetProductById(productId);
            Comment = await _commentService.GetAllCommentsByProductId(productId);
        }

        public async Task<IActionResult> OnPostConfirm(int commentId, int productId)
        {
            await _commentService.ConfirmComment(commentId);
            return RedirectToPage("./Index", new { productId = productId });
        }

        public async Task<IActionResult> OnPostDeConfirm(int commentId, int productId)
        {
            await _commentService.DeConfirmComment(commentId);
            return RedirectToPage("./Index", new { productId = productId });
        }
    }
}
