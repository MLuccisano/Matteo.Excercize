using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class TravelDocument : IFactory
    {
        public void choice()
        {
            Console.WriteLine("You have choice Travel document");
        }
    }
}
