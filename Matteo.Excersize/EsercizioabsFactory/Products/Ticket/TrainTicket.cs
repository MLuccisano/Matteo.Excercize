using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    class TrainTicket : Ticket
    {
        public TrainTicket(string name, decimal cost) : base(name, cost)
        { }
    }
}
