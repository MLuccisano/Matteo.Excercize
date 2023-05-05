using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Factory
{
    public class ClientChoiceFactory
    {
        public static abstractFactory GetFactory(Europe europe)
        {
            return new CovidFactory(europe);
        }
    }
}
