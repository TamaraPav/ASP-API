using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class SingleUserClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}
