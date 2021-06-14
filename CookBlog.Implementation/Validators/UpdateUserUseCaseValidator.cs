using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators
{
    public class UpdateUserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        public UpdateUserUseCaseValidator(CookBlogContext context)
        {
            RuleFor(x => x.UseCaseId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty()
                .Must(x => context.Users.Any(user => user.Id == x))
                .WithMessage("This user doesn't exist.");
        }
    }
}
