using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class SingleCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserClientDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<SingleCommentDto> Comments { get; set; } = new List<SingleCommentDto>();
    }
}
