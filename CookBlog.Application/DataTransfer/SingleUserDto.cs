using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class SingleUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> useCasesForUser { get; set; } = new List<int>();
        public ICollection<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}
