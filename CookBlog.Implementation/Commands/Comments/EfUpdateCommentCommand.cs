using AutoMapper;
using CookBlog.Application;
using CookBlog.Application.Commands.Comments;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Comments
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly CookBlogContext context;
        private readonly IApplicationActor actor;
        private readonly IMapper mapper;
        private readonly UpdateCommentValidator validator;

        public EfUpdateCommentCommand(CookBlogContext context, IApplicationActor actor, IMapper mapper, UpdateCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }
        public int Id => 14;

        public string Name => "EfUpdateCommentCommand";

        public void Execute(CommentDto request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Comment));
            }

            if (actor.Id != comment.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }

            var query = context.Comments.Where(x => x.Id == request.Id).FirstOrDefault();

            mapper.Map(request, query);

            context.SaveChanges();

        }
    }
}
