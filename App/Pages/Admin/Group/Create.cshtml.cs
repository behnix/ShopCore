using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Group
{
    public class CreateModel : PageModel
    {
        private readonly IGroupService _groupService;

        public CreateModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Post.Group Group { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _groupService.CreateGroup(Group);

            return RedirectToPage("./Index");
        }
    }
}