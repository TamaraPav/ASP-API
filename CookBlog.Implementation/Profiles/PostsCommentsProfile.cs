﻿using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class PostsCommentsProfile : Profile
    {
        public PostsCommentsProfile()
        {
            CreateMap<Comment, SingleCommentDto>();
            CreateMap<SingleCommentDto, Comment>();
        }
    }
}
