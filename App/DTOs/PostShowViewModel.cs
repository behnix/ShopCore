using System.Collections.Generic;
using App.Domain.Entities.Post;

namespace App.DTOs
{
    public class PostShowViewModel
    {
        public Post Post { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
