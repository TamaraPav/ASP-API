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
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly CookBlogContext context;
        private readonly DeleteCommentValidator validator;

        public EfDeleteCommentCommand(CookBlogContext context, DeleteCommentValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }
        public int Id => 12;

        public string Name => "EfDeleteCommentCommand";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var comment = context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }


            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
