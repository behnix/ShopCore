using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Domain.Entities.Product;
using App.Domain.Identity;
using App.Services.Identity;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppUserManager _userManager;

        public CommentService(ApplicationDbContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Comment> GetCommentById(int? commentId)
        {
            return await _context.Comments.SingleAsync(c => c.Id == commentId);
        }

        public async Task<List<Comment>> GetAllCommentsByProductId(int productId)
        {
            return await _context.Comments.Include(c=>c.User).Where(c => c.ProductId == productId).OrderByDescending(c=>c.CommentedOn).ToListAsync();
        }

        public async Task AddComment(Comment comment,string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            comment.CommentedOn = DateTime.Now;
            comment.IsConfirmed = false;
            comment.User = user;
            comment.UserId = user.Id;
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveComment(int? commentId)
        {
            _context.Comments.Remove(await GetCommentById(commentId));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CommentExists(int commentId)
        {
            return await _context.Comments.AnyAsync(p => p.Id == commentId);
        }

        public async Task ConfirmComment(int commentId)
        {
            var comment = await GetCommentById(commentId);
            comment.IsConfirmed = true;
            await UpdateComment(comment);
        }

        public async Task DeConfirmComment(int commentId)
        {
            var comment = await GetCommentById(commentId);
            comment.IsConfirmed = false;
            await UpdateComment(comment);
        }
    }
}
