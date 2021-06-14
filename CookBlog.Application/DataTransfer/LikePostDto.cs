using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.DataTransfer
{
    public class LikePostDto
    {
        public int Id { get; set; }
        public LikeStatus Status { get; set; }
        public UserClientDto User { get; set; }
    }
}
