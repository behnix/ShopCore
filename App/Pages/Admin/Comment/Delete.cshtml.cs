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
    public class DeleteModel : PageModel
    {
        private readonly ICommentService _commentService;

        public DeleteModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [BindProperty]
        public Domain.Entities.Product.Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _commentService.GetCommentById(id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _commentService.GetCommentById(id);
            var productId = Comment.ProductId;
            if (Comment != null)
            {
                await _commentService.RemoveComment(id);
            }

            return RedirectToPage("./Index", new {productId = productId});
        }
    }
}
