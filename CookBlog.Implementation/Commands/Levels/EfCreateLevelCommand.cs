using AutoMapper;
using CookBlog.Application.Commands.Level;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Levels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Levels
{
    public class EfCreateLevelCommand : ICreateLevelCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateLevelValidator validator;

        public EfCreateLevelCommand(CookBlogContext context, IMapper mapper, CreateLevelValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 8;

        public string Name => "EfCreateLevelCommand";

        public void Execute(LevelDto request)
        {
            validator.ValidateAndThrow(request);

            var level = mapper.Map<Level>(request);
            context.Levels.Add(level);
            context.SaveChanges();


        }
    }
}
