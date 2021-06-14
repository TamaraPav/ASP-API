using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class UsersClientProfile : Profile
    {
        public UsersClientProfile()
        {
            CreateMap<User, UserClientDto>();
            CreateMap<UserClientDto, User>();
        }
    }
}
