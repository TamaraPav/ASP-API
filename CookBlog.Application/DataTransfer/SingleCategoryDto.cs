using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class SingleCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeClientDto> Recipes { get; set; } = new List<RecipeClientDto>();
    }
}
