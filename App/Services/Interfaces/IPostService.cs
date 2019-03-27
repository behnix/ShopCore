using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities.Post;
using Microsoft.AspNetCore.Http;
namespace App.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();

        Task<List<Post>> GetAllPublishedPosts();

        Task<List<Post>> GetAllArchivedPost();

        Task<List<Post>> GetAllPostInGroup(int postGroupId, int selfId);
        
        Task<List<Post>> GetPublishedPosts(int take);

        Task<int> AddPost(Post post,IFormFile postImage, string tags);

        Task UpdatePostAsync(Post post, IFormFile postImage, string tags, string oldImage);

        Task UpdateNormal(Post post);

        Task IncreaseVisit(int postId);

        Task<Post> GetPostById(int? postId);

        Task<bool> RemovePost(int? postId);

        Task SaveChangeAsync();

        Task<bool> IsPostTitleInBrowserRepeated(string postTitleInBrowser);

        Task SetShortUrlToPost(int postId);

        Task<Post> GetPostByShortUrl(string shortUrl);

        Task<Post> GetPostByTitleInBrowser(string titleInBrowser);

        bool PostExists(int id);

        Task ArchivePost(int id);

        Task PublishPost(int id);
    }
}
