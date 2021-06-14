using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
