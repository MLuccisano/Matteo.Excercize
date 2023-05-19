using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    internal abstract class AbstractFactory
    {
        public abstract IFactory getFactory(ref char input);
    }
}
