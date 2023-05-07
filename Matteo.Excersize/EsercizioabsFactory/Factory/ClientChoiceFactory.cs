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
            CovidFactory covidFactory =  new CovidFactory(europe);
            return new TicketFactory(covidFactory);           
        }
    }
}
