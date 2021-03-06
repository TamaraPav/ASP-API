using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(CookBlogContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).NotEmpty()
                    .Must(x => !context.Users.Any(user => user.Email == x))
                    .WithMessage("User with this email already exists.")
                    .EmailAddress();

            RuleFor(x => x.useCasesForUser)
                .NotEmpty();

        }
    }
}
