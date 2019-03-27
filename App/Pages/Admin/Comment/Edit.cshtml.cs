using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;

namespace App.Pages.Admin.Comment
{
    public class EditModel : PageModel
    {
        private readonly ICommentService _commentService;

        public EditModel(ICommentService commentService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await _commentService.UpdateComment(Comment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CommentExists(Comment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index" , new { productId= Comment.ProductId });
        }

        private async Task<bool> CommentExists(int commentId)
        {
            return await _commentService.CommentExists(commentId);
        }
    }
}
