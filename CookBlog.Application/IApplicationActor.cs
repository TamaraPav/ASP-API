using System;
using System.Collections.Generic;
using System.Text;

namespace CookBlog.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
