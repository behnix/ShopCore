using System.Collections.Generic;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Page
{
    public class CreateModel : PageModel
    {
        private readonly IPageService _pageService;
        private readonly IGroupService _groupService;

        public CreateModel(IPageService pageService, IGroupService groupService)
        {
            _pageService = pageService;
            _groupService = groupService;
        }


        public IActionResult OnGet()
        {
            var selectItem = new Dictionary<int,string>();
            foreach (var grp in _groupService.GetAllGroup())
                selectItem.Add(grp.GroupId,grp.GroupTitle);

            ViewData["Groups"] = selectItem;
            return Page();
        }

        [BindProperty]
        public new Domain.Entities.Page.Page Page { get; set; }

        public async Task<IActionResult> OnPostAsync(IFormFile postImageUp, string tags)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _pageService.IsPageTitleInBrowserRepeated(Page.PageTitleInBrowser))
            {
                ModelState.AddModelError("Post.PageTitleInBrowser", "قبلا صفحه ای با این عنوان برای مرورگر ثبت شده است!");
                return Page();
            }

            await _pageService.AddPage(Page);

            return RedirectToPage("./Index");
        }


    }
}