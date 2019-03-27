using System.Collections.Generic;
using App.Domain.Entities.Post;
using App.Domain.Entities.Setting;

namespace App.DTOs
{
    public class HomePageViewModel
    {
        public Setting Setting { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
