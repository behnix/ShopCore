using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Post;
using App.Services.Interfaces;

namespace App.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;

        public PostModel(IPostService postService)
        {
            _postService = postService;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(string titleInBrowser)
        {
            if (titleInBrowser == null)
            {
                return NotFound();
            }

            Post = await _postService.GetPostByTitleInBrowser(titleInBrowser);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
