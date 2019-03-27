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
    public class BlogModel : PageModel
    {
        private readonly IPostService _postService;

        public BlogModel(IPostService postService)
        {
            _postService = postService;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _postService.GetAllPublishedPosts();
        }
    }
}
