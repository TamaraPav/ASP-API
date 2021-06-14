using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
