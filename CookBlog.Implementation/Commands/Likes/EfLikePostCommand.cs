using AutoMapper;
using CookBlog.Application;
using CookBlog.Application.Commands.Likes;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Likes
{
    public class EfLikePostCommand : ILikePostCommand
    {

        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;
        private readonly LikeValidator validator;

        public EfLikePostCommand(CookBlogContext context, IMapper mapper, LikeValidator validator, IApplicationActor actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
            this.actor = actor;
        }

        public int Id => 20;

        public string Name => "EfLikePostCommand";

        public void Execute(LikeDto request)
        {
            validator.ValidateAndThrow(request);
            var findLike = context.Likes.Where(x => x.RecipeId == request.RecipeId && x.UserId == request.UserId).FirstOrDefault();

            if (findLike == null)
            {
                var like = mapper.Map<Like>(request);
                context.Likes.Add(like);
                context.SaveChanges();
            }
            else
            {
                findLike.Status = request.Status;
                context.SaveChanges();
            }

        }
    }
}
