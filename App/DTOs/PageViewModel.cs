using System.Collections.Generic;
using App.Domain.Entities.Page;
using App.Domain.Entities.Post;

namespace App.DTOs
{
    public class PageViewModel
    {
        public Page Page { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
