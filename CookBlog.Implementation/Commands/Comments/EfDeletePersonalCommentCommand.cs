using CookBlog.Application;
using CookBlog.Application.Commands.Comments;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Comments
{
    public class EfDeletePersonalCommentCommand : IDeletePersonalCommentCommand
    {
        private readonly CookBlogContext context;
        private readonly IApplicationActor actor;
        private readonly DeleteCommentValidator validator;

        public EfDeletePersonalCommentCommand(CookBlogContext context, IApplicationActor actor, DeleteCommentValidator validator)
        {
            this.validator = validator;
            this.context = context;
            this.actor = actor;
        }
        public int Id => 13;

        public string Name => "EfDeletePersonalCommentCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }

            if (actor.Id != comment.UserId)
            {
                throw new UnAuthorizedAccessUserException(actor, Name);
            }


            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
