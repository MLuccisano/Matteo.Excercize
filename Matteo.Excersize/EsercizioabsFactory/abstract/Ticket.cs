using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    abstract class Ticket
    {
        string _name;
        decimal _cost;

        public Ticket(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }
    }
}
