using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Domain.Entities
{
    public class Like : Entity
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public LikeStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }

    }

    public enum LikeStatus
    {
        Liked,
        Disliked,
        Null
    }
}
