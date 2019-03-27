using System.Threading.Tasks;
using App.Core.Convertors;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Admin.Post
{
    public class EditModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IGroupService _groupService;
        private readonly AppUserManager _userManager;
        private readonly ITagService _tagService;
        private readonly IPostTagService _postTagService;

        public EditModel(IPostService postService, ITagService tagService, IGroupService groupService, IPostTagService postTagService, AppUserManager userManager)
        {
            _postService = postService;
            _tagService = tagService;
            _groupService = groupService;
            _postTagService = postTagService;
            _userManager = userManager;
        }



        [BindProperty]
        public Domain.Entities.Post.Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _postService.GetPostById(id);

            if (Post == null)
            {
                return NotFound();
            }

            ViewData["PostImage"] = Post.PostImage ?? "no-image.png";
            Post.PostTitleInBrowser = TextConvertor.ReplaceLetters(Post.PostTitleInBrowser, '-', ' ');
            ViewData["GroupId"] = new SelectList(_groupService.GetAllGroup(), "GroupId", "GroupTitle");
            //ViewData["Author"] = new SelectList(_userService.GetAllUsers(), "UserId", "UserName");
            var tagsPost = "";
            foreach (var tag in _postTagService.GetAllTagsByPostId(id))
                tagsPost += tag.Tag.TagTitle + ",";

            ViewData["Tags"] = tagsPost.Length == 0 ? null : tagsPost.Substring(0, tagsPost.Length - 1);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile postImageUp, string tags, string oldImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _postService.UpdatePostAsync(Post, postImageUp, tags, oldImage);

            try
            {
                await _postService.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostExists(int id)
        {
            return _postService.PostExists(id);
        }
    }
}
