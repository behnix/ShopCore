using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Page
{
    public class DeleteModel : PageModel
    {
        private readonly IPageService _pageService;

        public DeleteModel(IPageService pageService)
        {
            _pageService = pageService;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Page = await _pageService.GetPageById(id);

            if (Page != null)
            {
                await _pageService.RemovePage(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
