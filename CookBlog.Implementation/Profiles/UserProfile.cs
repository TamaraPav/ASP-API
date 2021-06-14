using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                dto => dto.useCasesForUser,
                us => us.MapFrom(x =>
               x.UserUseCases.Select(y => y.UseCaseId).ToList()));

            CreateMap<UserDto, User>();
        }
    }
}
