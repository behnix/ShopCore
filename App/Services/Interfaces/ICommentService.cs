using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities.Product;

namespace App.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> GetCommentById(int? commentId);

        Task<List<Comment>> GetAllCommentsByProductId(int productId);

        Task AddComment(Comment comment, string userName);

        Task UpdateComment(Comment comment);

        Task RemoveComment(int? commentId);

        Task<bool> CommentExists(int commentId);

        Task ConfirmComment(int commentId);

        Task DeConfirmComment(int commentId);
    }
}
