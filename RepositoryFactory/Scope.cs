using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public class Scope
    {
        public static IFactory Instance { get; set; }
    }
}
