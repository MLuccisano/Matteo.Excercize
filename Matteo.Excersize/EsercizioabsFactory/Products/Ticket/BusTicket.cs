using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    class BusTicket : Ticket
    {
        public BusTicket(string name, decimal cost) : base(name, cost)
        {
        }
    }
}
