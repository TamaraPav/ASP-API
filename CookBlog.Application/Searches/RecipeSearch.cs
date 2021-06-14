using CookBlog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Searches
{
    public class RecipeSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
