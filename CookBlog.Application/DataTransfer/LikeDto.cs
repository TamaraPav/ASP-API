using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class LikeDto
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public LikeStatus Status { get; set; }
    }
}
