using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Admin.Group
{
    public class EditModel : PageModel
    {
        private readonly IGroupService _groupService;

        public EditModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [BindProperty]
        public Domain.Entities.Post.Group Group { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Group = await _groupService.GetGroupByGroupId(id);

            if (Group == null)
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

            _groupService.EditGroup(Group);

            try
            {
                await _groupService.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(Group.GroupId))
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

        private bool GroupExists(int id)
        {
            return _groupService.GroupExists(id);
        }
    }
}
