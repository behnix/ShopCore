using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Identity;

namespace App.Domain.Entities.Product
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        [Display(Name = "دیدگاه")]
        [MaxLength(2000, ErrorMessage = "{0} نمیتواند بیشتر از {1} حرف باشد.")]
        public string Content { get; set; }

        public DateTime CommentedOn { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
