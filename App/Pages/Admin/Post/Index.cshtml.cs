using System.Collections.Generic;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Post
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;

        public IndexModel(IPostService postService)
        {
            _postService = postService;
        }

        public IList<Domain.Entities.Post.Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _postService.GetAllPosts();
        }

        public async Task<IActionResult> OnPostArchive(int id)
        {
            await _postService.ArchivePost(id);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostPublish(int id)
        {
            await _postService.PublishPost(id);
            return RedirectToPage("./Index");
        }
    }
}
