using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Domain.Entities
{
    public class Level : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
