using System.Threading.Tasks;
using App.Core.Convertors;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Admin.Post
{
    public class CreateModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IGroupService _groupService;
        private readonly AppUserManager _userManager;
        private readonly ITagService _tagService;

        public CreateModel(IPostService postService, IGroupService groupService, ITagService tagService, AppUserManager userManager)
        {
            _postService = postService;
            _groupService = groupService;
            _tagService = tagService;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["GroupId"] = new SelectList(_groupService.GetAllGroup(), "GroupId", "GroupTitle");
            ViewData["Author"] = new SelectList(_userManager.Users, "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Post.Post Post { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile postImageUp, string tags)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _postService.IsPostTitleInBrowserRepeated(TextConvertor.ReplaceLetters(TextConvertor.FixingText(Post.PostTitleInBrowser), ' ', '-')))
            {
                ModelState.AddModelError("Post.PostTitleInBrowser", "قبلا مطلبی با این عنوان برای مرورگر ثبت شده است!");
                ViewData["GroupId"] = new SelectList(_groupService.GetAllGroup(), "GroupId", "GroupTitle");
                ViewData["Author"] = new SelectList(_userManager.Users, "UserId", "UserName");
                return Page();
            }

            await _postService.AddPost(Post, postImageUp, tags);

            return RedirectToPage("./Index");
        }


    }
}