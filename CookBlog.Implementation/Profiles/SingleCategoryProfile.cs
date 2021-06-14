using AutoMapper;
using CookBlog.Application.DataTransfer;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Profiles
{
    public class SingleCategoryProfile : Profile
    {
        public SingleCategoryProfile()
        {
            CreateMap<Category, SingleCategoryDto>()
                .ForMember(
                dto => dto.Recipes,
                ent => ent.MapFrom(x =>
                x.Recipes.ToList()
                ));

            CreateMap<SingleCategoryDto, Category>()
            .ForMember(
            dto => dto.Recipes,
            ent => ent.MapFrom(x =>
            x.Recipes.Select(y => y.Id).ToList()
            ));


        }
    }
}
