using EsercizioabsFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Factory
{
    class AirplaneAgency : Agency
    {
        List<Ticket> listAgency;

        public AirplaneAgency(string name) : base(name)
        {
            listAgency = new List<Ticket>();
            
        }

        


    }
}
