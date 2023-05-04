using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory

{
    public abstract class abstractFactory
    {
        public abstract IFactory GetChoice(string nameAgency);
    }
}
