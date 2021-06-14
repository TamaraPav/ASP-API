using CookBlog.Application;
using CookBlog.Application.Commands.Categories;
using CookBlog.Application.Commands.Comments;
using CookBlog.Application.Commands.Level;
using CookBlog.Application.Commands.Likes;
using CookBlog.Application.Commands.Recipe;
using CookBlog.Application.Commands.User;
using CookBlog.Application.Commands.UserUseCase;
using CookBlog.Application.Queries;
using CookBlog.Application.Queries.Categories;
using CookBlog.Application.Queries.Levels;
using CookBlog.Application.Queries.Recipes;
using CookBlog.Application.Queries.Users;
using CookBlog.DataAccess;
using CookBlog.Implementation.Commands;
using CookBlog.Implementation.Commands.Categories;
using CookBlog.Implementation.Commands.Comments;
using CookBlog.Implementation.Commands.Levels;
using CookBlog.Implementation.Commands.Likes;
using CookBlog.Implementation.Commands.Recipes;
using CookBlog.Implementation.Commands.Users;
using CookBlog.Implementation.Queries;
using CookBlog.Implementation.Queries.Categories;
using CookBlog.Implementation.Queries.Levels;
using CookBlog.Implementation.Queries.Recipes;
using CookBlog.Implementation.Queries.Users;
using CookBlog.Implementation.Validators;
using CookBlog.Implementation.Validators.Categories;
using CookBlog.Implementation.Validators.Comments;
using CookBlog.Implementation.Validators.Levels;
using CookBlog.Implementation.Validators.Recipes;
using CookBlog.Implementation.Validators.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBlog.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //Commands
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ICreateLevelCommand, EfCreateLevelCommand>();
            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCasesCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();
            services.AddTransient<IDeleteLevelCommand, EfDeleteLevelCommand>();
            services.AddTransient<IUpdateLevelCommand, EfUpdateLevelCommand>();
            services.AddTransient<IUpdateUserUseCaseCommand, EfUpdateUserUseCaseCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<ICreateRecipeCommand, EfCreateRecipeCommand>();
            services.AddTransient<IUpdateRecipeCommand, EfUpdateRecipeCommand>();
            services.AddTransient<IDeleteRecipeCommand, EfDeleteRecipeCommand>();
            services.AddTransient<IUpdatePersonalRecipeCommand, EfUpdatePersonalRecipeCommand>();
            services.AddTransient<IDeletePersonalRecipeCommand, EfDeletePersonalRecipeCommand>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IDeletePersonalCommentCommand, EfDeletePersonalCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
            services.AddTransient<ILikePostCommand, EfLikePostCommand>();


            //Queries
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetLevelsQuery, EfGetLevelsQuery>();
            services.AddTransient<IGetOneUserClientQuery, EfGetSingleUserClientQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUsersClientQuery, EfGetUsersClientQuery>();
            services.AddTransient<IGetRecipeQuery, EfGetRecipesQuery>();
            services.AddTransient<IGetOneRecipeQuery, EfGetOneRecipeQuery>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();

            //Validators
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateLevelValidator>();
            services.AddTransient<DeleteLevelValidator>();
            services.AddTransient<CreateUserUseCaseValidator>();
            services.AddTransient<UpdateLevelValidator>();
            services.AddTransient<UpdateUserUseCaseValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<CreateRecipeValidator>();
            services.AddTransient<DeleteRecipeValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateCommentValidator>();
            services.AddTransient<DeleteCommentValidator>();
            services.AddTransient<LikeValidator>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();


                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnnonymusActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });

        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<CookBlogContext>();

                return new JwtManager(context);
            });

            //jwt token setup
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
