using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Domain.Entities.Product;

namespace App.Pages.Admin.ConfigGroup
{
    public class IndexModel : PageModel
    {
        private readonly App.Data.ApplicationDbContext _context;

        public IndexModel(App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.Product.ConfigGroup> ConfigGroup { get;set; }

        public async Task OnGetAsync()
        {
            ConfigGroup = await _context.ConfigGroups.ToListAsync();
        }
    }
}
