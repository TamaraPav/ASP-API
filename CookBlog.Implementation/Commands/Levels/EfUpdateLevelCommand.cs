using AutoMapper;
using CookBlog.Application.Commands.Level;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Levels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Levels
{
    public class EfUpdateLevelCommand : IUpdateLevelCommand
    {
        private CookBlogContext context;
        private IMapper mapper;
        private readonly UpdateLevelValidator validator;

        public EfUpdateLevelCommand(CookBlogContext context, IMapper mapper, UpdateLevelValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "EfUpdateLevelCommand";

        public void Execute(LevelDto request)
        {
            validator.ValidateAndThrow(request);
            var findLevel = context.Levels.Find(request.Id);
            if (findLevel == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Level));
            }

            var level = context.Levels.Where(x => x.Id == request.Id).First();

            mapper.Map(request, level);
            context.SaveChanges();
        }
    }
}
