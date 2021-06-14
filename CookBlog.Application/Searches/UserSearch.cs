using CookBlog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
