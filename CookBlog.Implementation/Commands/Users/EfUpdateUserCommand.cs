using AutoMapper;
using CookBlog.Application.Commands.User;
using CookBlog.Application.DataTransfer;
using CookBlog.Application.Exceptions;
using CookBlog.DataAccess;
using CookBlog.Domain.Entities;
using CookBlog.Implementation.Validators.Users;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBlog.Implementation.Commands.Users
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly CookBlogContext context;
        private readonly IMapper mapper;
        private readonly UpdateUserValidator validator;

        public EfUpdateUserCommand(CookBlogContext context, IMapper mapper, UpdateUserValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public int Id => 33;

        public string Name => "Update User";



        public void Execute(UserDto request)
        {
            validator.ValidateAndThrow(request);

            var findUser = context.Users.Find(request.Id);

            if (findUser == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            var user = context.Users.Include(x => x.UserUseCases).Where(x => x.Id == request.Id).First();

            mapper.Map(request, user);


            foreach (var uc in user.UserUseCases)
            {
                context.Remove(uc);
            }

            foreach (var ucNew in request.useCasesForUser)
            {
                context.UserUseCases.Add(new UserUseCases
                {
                    UseCaseId = ucNew,
                    UserId = request.Id
                });
            }


            user.Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password);

            context.SaveChanges();

        }
    }
}
