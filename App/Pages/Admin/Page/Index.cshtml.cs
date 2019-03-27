using System.Collections.Generic;
using System.Threading.Tasks;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Page
{
    public class IndexModel : PageModel
    {
        private readonly IPageService _pageService;

        public IndexModel(IPageService pageService)
        {
            _pageService = pageService;
        }

        public new IList<Domain.Entities.Page.Page> Page { get;set; }

        public async Task OnGetAsync()
        {
            Page = await _pageService.GetAllPages();
        }
        
    }
}
