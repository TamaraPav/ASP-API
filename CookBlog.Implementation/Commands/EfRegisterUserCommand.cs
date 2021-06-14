using AutoMapper;
using CookBlog.Application.Commands.User;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Email;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly CookBlogContext context;
        private readonly RegisterUserValidator validator;
        private readonly IMapper mapper;

        private readonly IEmailSender email;


        public EfRegisterUserCommand(CookBlogContext context, RegisterUserValidator validator, IMapper mapper, IEmailSender email)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.email = email;
        }
        public int Id => 1;
        public string Name => "User Registration";

        private IEnumerable<int> useCasesForUser = new List<int> { 11, 13, 14, 17, 19, 20, 23, 25, 26, 30 };

        public void Execute(RegisterUserDto request)
        {
            validator.ValidateAndThrow(request);
            var user = mapper.Map<User>(request);

            user.Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password);
            context.Add(user);
            context.SaveChanges();

            int id = user.Id;
            foreach (var uc in useCasesForUser)
            {
                context.UserUseCases.Add(new UserUseCases
                {
                    UserId = id,
                    UseCaseId = uc
                });
            }

            context.SaveChanges();

            email.Send(new SendEmailDto
            {
                Content = "<h3>Uspesna registracija. </h3>",
                SendTo = request.Email,
                Subject = "Successful registration"

            });

        }
    }
}
