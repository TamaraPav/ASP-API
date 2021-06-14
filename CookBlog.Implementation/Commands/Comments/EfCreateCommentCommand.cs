using AutoMapper;
using CookBlog.Application.Commands.Comments;
using CookBlog.Application;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CookBlog.Implementation.Validators.Comments;
using FluentValidation;

namespace CookBlog.Implementation.Commands.Comments
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly CookBlogContext context;
        private readonly IApplicationActor actor;
        private readonly IMapper mapper;
        private readonly CreateCommentValidator validator;

        public EfCreateCommentCommand(CookBlogContext context, IApplicationActor actor, IMapper mapper, CreateCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }
        public int Id => 11;

        public string Name => "EfCreateCommentCommand";

        public void Execute(CommentDto request)
        {
            validator.ValidateAndThrow(request);
            request.UserId = actor.Id;
            var comment = mapper.Map<Comment>(request);

            context.Add(comment);
            context.SaveChanges();
        }
    }
}
