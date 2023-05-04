using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class agencyAirplane : IFactory
    {
        public void choice()
        {
            Console.WriteLine("You choose Airplane agency");
        }
    }
}
