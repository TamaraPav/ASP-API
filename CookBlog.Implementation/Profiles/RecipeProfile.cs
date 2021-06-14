using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();

            CreateMap<RecipeDto, Recipe>().ForMember(x => x.Picture, opt => opt.Ignore())
;
        }
    }
}
