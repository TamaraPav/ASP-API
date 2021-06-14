using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int LevelId { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
