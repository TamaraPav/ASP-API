using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application.Exceptions
{
    public class UnAuthorizedAccessUserException : Exception
    {
        public UnAuthorizedAccessUserException(IApplicationActor actor, string UseCaseName)
            : base($"User with identity: {actor.Identity} with id: {actor.Id} has tried to execute Use Case {UseCaseName}")
        {

        }
    }
}
