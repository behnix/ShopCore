using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Admin.Page
{
    public class EditModel : PageModel
    {
        private readonly IPageService _pageService;
        private readonly IGroupService _groupService;

        public EditModel(IPageService pageService, IGroupService groupService)
        {
            _pageService = pageService;
            _groupService = groupService;
        }


        [BindProperty]
        public new Domain.Entities.Page.Page Page { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Page = await _pageService.GetPageById(id);

            if (Page == null)
            {
                return NotFound();
            }

            var selectItem = new Dictionary<int, string>();
            foreach (var grp in _groupService.GetAllGroup())
                selectItem.Add(grp.GroupId, grp.GroupTitle);

            ViewData["Groups"] = selectItem;
            Page.PageTitleInBrowser = TextConvertor.ReplaceLetters(Page.PageTitleInBrowser, '-', ' ');

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile postImageUp, string tags, string oldImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await _pageService.UpdatePage(Page);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PageExists(Page.PageId))
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

        private async Task<bool> PageExists(int id)
        {
            return await _pageService.PageExists(id);
        }
    }
}
