using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class EmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
