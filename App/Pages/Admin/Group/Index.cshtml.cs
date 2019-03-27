using System.Collections.Generic;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin.Group
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;

        public IndexModel(IGroupService groupService)
        {
            _groupService = groupService;   
        }

        public IEnumerable<Domain.Entities.Post.Group> Group { get;set; }

        public void OnGet()
        {
            Group = _groupService.GetAllGroup();
        }
    }
}
