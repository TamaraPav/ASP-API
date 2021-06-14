using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public int CategoryId { get; set; }
        public int LevelId { get; set; }
        public int UserId { get; set; }
    }
}
