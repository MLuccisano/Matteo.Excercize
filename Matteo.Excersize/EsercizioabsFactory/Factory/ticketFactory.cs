using EsercizioabsFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Factory
{
    public class TicketFactory : abstractFactory
    {
        CovidFactory _covidFactory;

        public TicketFactory(CovidFactory covidFactory)
        {
            _covidFactory = covidFactory;
        }

        public override void GetInfoSectionA()
        {
            _covidFactory.GetInfoSectionA();
            
            
        }

    }
}
