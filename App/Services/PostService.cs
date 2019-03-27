﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Core.Uploader;
using App.Data;
using App.Domain.Entities.Post;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITagService _tagService;
        private readonly IPostTagService _postTagService;

        public PostService(ApplicationDbContext context, ITagService tagService, IPostTagService postTagService)
        {
            _context = context;
            _tagService = tagService;
            _postTagService = postTagService;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.Include(p => p.Group)
                .Include(p => p.User).OrderByDescending(p=>p.PostId).ToListAsync();
        }

        public async Task<List<Post>> GetAllPublishedPosts()
        {
            return await _context.Posts.Include(p => p.Group)
                .Include(p => p.User).Where(p => p.IsPublished).OrderByDescending(p => p.PostId).ToListAsync();
        }

        public async Task<List<Post>> GetAllArchivedPost()
        {
            return await _context.Posts.Include(p => p.Group)
                .Include(p => p.User).Where(p => !p.IsPublished).OrderByDescending(p => p.PostId).ToListAsync();
        }

        public async Task<List<Post>> GetAllPostInGroup(int postGroupId, int selfId)
        {
            return await _context.Posts.Include(p => p.Group)
                .Where(p => p.Group.GroupId == postGroupId && p.PostId != selfId && p.IsPublished).OrderByDescending(p => p.PostId).Take(10).ToListAsync();
        }

        public async Task<List<Post>> GetPublishedPosts(int take)
        {
            return await _context.Posts.Include(p => p.Group)
                .Include(p => p.User).Where(p => p.IsPublished).OrderByDescending(p => p.PostId).Take(take).ToListAsync();
        }

        public async Task<int> AddPost(Post post,IFormFile postImageUp, string tags)
        {
            post.PostCreationDate = DateTime.Now;
            post.PostUpdateDate = DateTime.Now;
            post.PostVisit = 0;
            post.IsPublished = true;
            post.PostTitleInBrowser = TextConvertor.ReplaceLetters(TextConvertor.FixingText(post.PostTitleInBrowser), ' ', '-');

            post.PostImage = postImageUp == null ? "no-image.png" : ImageTools.UploadImageNormal("no-image.png", postImageUp, "no-image.png", "wwwroot/assets/posts/image",true, "wwwroot/assets/posts/thumb",240);

            if (tags != null)
            {
                var postTagAsArray = TextConvertor.TextToArray(tags, ",");
                var initialMiddlePostTagTableList = new List<PostTag>();
                foreach (var tag in postTagAsArray)
                {
                    var currentTag = TextConvertor.FixingText(tag);
                    if (!await _tagService.ExistTag(currentTag))
                    {
                        var newTagForSaveToTagsTable = new Tag { TagTitle = currentTag };
                        _tagService.AddTag(newTagForSaveToTagsTable);
                        initialMiddlePostTagTableList.Add(InitialMiddlePostTagTable(post.PostId,
                            newTagForSaveToTagsTable.TagId));
                    }
                    else
                    {
                        var existTagInTagsTable = _tagService.GetTagByTagTitle(currentTag);
                        initialMiddlePostTagTableList.Add(InitialMiddlePostTagTable(post.PostId,
                            existTagInTagsTable.TagId));
                    }

                    post.PostTags = initialMiddlePostTagTableList;
                }
            }

            await _context.Posts.AddAsync(post);
            await SaveChangeAsync();
            await SetShortUrlToPost(post.PostId);
            return post.PostId;
        }

        public PostTag InitialMiddlePostTagTable(int postId, int tagId)
        {
            var initialMiddlePostTagTable = new PostTag
            {
                PostId = postId,
                TagId = tagId
            };
            return initialMiddlePostTagTable;
        }

        public async Task UpdatePostAsync(Post post, IFormFile postImageUp, string tags, string oldImage)
        {
            var postTags = _postTagService.GetAllTagsByPostId(post.PostId);
            foreach (var tagTag in postTags)
                _postTagService.RemoveTagFromPostTagByPostId(post.PostId, tagTag.TagId);
            await _context.SaveChangesAsync();

            post.PostUpdateDate = DateTime.Now;
            post.PostTitleInBrowser = TextConvertor.ReplaceLetters(TextConvertor.FixingText(post.PostTitleInBrowser), ' ', '-');
            post.PostImage = postImageUp == null ? oldImage : ImageTools.UploadImageNormal(oldImage, postImageUp, "no-image.png", "wwwroot/assets/posts/image", true, "wwwroot/assets/posts/thumb", 240);

            if (tags != null)
            {
                var postTagAsArray = TextConvertor.TextToArray(tags, ",");
                var initialMiddlePostTagTableList = new List<PostTag>();
                foreach (var tag in postTagAsArray)
                {
                    var currentTag = TextConvertor.FixingText(tag);
                    if (!await _tagService.ExistTag(currentTag))
                    {
                        var newTagForSaveToTagsTable = new Tag { TagTitle = currentTag };
                        _tagService.AddTag(newTagForSaveToTagsTable);
                        initialMiddlePostTagTableList.Add(InitialMiddlePostTagTable(post.PostId,
                            newTagForSaveToTagsTable.TagId));
                    }
                    else
                    {
                        var existTagInTagsTable = _tagService.GetTagByTagTitle(currentTag);
                        initialMiddlePostTagTableList.Add(InitialMiddlePostTagTable(post.PostId,
                            existTagInTagsTable.TagId));
                    }

                    post.PostTags = initialMiddlePostTagTableList;
                    foreach (var pt in initialMiddlePostTagTableList)
                    {
                        await _context.PostTags.AddAsync(pt);
                    }
                }
            }

            _context.Posts.Attach(post).State = EntityState.Modified;
            await SaveChangeAsync();
            
        }

        public async Task UpdateNormal(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPostById(int? postId)
        {
            return await _context.Posts.Include(p=>p.Group).Include(p=>p.User).SingleOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<bool> RemovePost(int? postId)
        {
            var post = await GetPostById(postId);
            _context.Posts.Remove(post);
            return _context.SaveChanges() != 0;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsPostTitleInBrowserRepeated(string postTitleInBrowser)
        {
            return await _context.Posts.AnyAsync(p => p.PostTitleInBrowser == postTitleInBrowser);
        }

        public async Task SetShortUrlToPost(int postId)
        {
            var postForAddShortUrl = await GetPostById(postId);
            postForAddShortUrl.ShortUrl = Base36.Encode(postId);
            await UpdateNormal(postForAddShortUrl);
            await SaveChangeAsync();
        }

        public async Task<Post> GetPostByShortUrl(string shortUrl)
        {
            return await _context.Posts.SingleOrDefaultAsync(p => p.ShortUrl == shortUrl);
        }

        public async Task<Post> GetPostByTitleInBrowser(string titleInBrowser)
        {
            return await _context.Posts.Include(p => p.User)
                .SingleOrDefaultAsync(p => p.PostTitleInBrowser == titleInBrowser);
        }
        

        public bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }

        public async Task ArchivePost(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == id);
            if (post == null) return;
            post.IsPublished = false;
            await UpdateNormal(post);
        }

        public async Task PublishPost(int id)
        {
            var post = await GetPostById(id);
            if (post == null) return;
            post.IsPublished = true;
            await UpdateNormal(post);
        }

        public async Task IncreaseVisit(int postId)
        {
            var post = await GetPostById(postId);
            if (post == null) return;
            post.PostVisit += 1;
            await UpdateNormal(post);
        }
    }
}
