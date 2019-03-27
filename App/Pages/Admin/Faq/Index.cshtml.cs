using System.Collections.Generic;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Faq
{
    public class IndexModel : PageModel
    {
        private readonly IFaqService _faqService;

        public IndexModel(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public IList<Domain.Entities.Faq.Faq> Faq { get;set; }

        public async Task OnGetAsync()
        {
            Faq = await _faqService.GetAllPublishedFaq();
        }
    }
}
