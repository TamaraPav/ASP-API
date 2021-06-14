using CookBlog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBlog.API.Core
{
    public class AnnonymusActor : IApplicationActor
    {
        public int Id => 0;
        public string Identity => "Neautorizovan korisnik.";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 23, 25, 26, 27, 30 };
    }
}
