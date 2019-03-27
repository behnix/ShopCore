using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Admin.Faq
{
    public class EditModel : PageModel
    {
        private readonly IFaqService _faqService;

        public EditModel(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [BindProperty]
        public Domain.Entities.Faq.Faq Faq { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Faq = await _faqService.GetFaqById(id);

            if (Faq == null)
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


            try
            {
                await _faqService.UpdateFaq(Faq);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaqExists(Faq.FaqId))
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

        private bool FaqExists(int id)
        {
            return _faqService.FaqExists(id);
        }
    }
}
