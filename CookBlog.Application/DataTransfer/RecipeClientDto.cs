using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class RecipeClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public CategoryDto Category { get; set; }
        public LevelDto Level { get; set; }
        public UserClientDto User { get; set; }

        public ICollection<SingleCommentDto> Comments { get; set; } = new List<SingleCommentDto>();
        public ICollection<LikePostDto> Likes { get; set; } = new List<LikePostDto>();
    }
}
