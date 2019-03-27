using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Faq
{
    public class CreateModel : PageModel
    {
        private readonly IFaqService _faqService;

        public CreateModel(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Faq.Faq Faq { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _faqService.AddNewFaq(Faq);

            return RedirectToPage("./Index");
        }
    }
}