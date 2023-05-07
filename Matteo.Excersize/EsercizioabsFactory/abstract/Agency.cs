using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory
{
    abstract class Agency
    {
        string _name;
        public Agency(string name)
        {
            _name = name;
        }
    }
}
