using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Domain.Entities
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }

    }
}
