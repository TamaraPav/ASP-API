using AutoMapper;
using CookBlog.Application.Commands.User;
using CookBlog.Application.DataTransfer;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Implementation.Commands.Users
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly CreateUserValidator validator;

        public EfCreateUserCommand(CookBlogContext context, IMapper mapper, CreateUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 31;

        public string Name => "Create User";

        private IEnumerable<int> useCasesForUser = new List<int> { 1, 24 };

        public void Execute(UserDto request)
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
        }
    }
}
