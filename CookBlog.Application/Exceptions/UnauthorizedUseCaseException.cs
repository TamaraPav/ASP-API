using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Exceptions
{
    public class UnAuthorizedUseCaseException : Exception
    {
        public UnAuthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with an id {actor.Id} - {actor.Identity} tried to execute {useCase.Name}")
        {

        }
    }
}
