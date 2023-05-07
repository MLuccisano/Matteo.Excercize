using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    class TravelDocumentGreenZone : ProductFactory
    {
        public TravelDocumentGreenZone()
        {
            Console.WriteLine("Nella Zona verde va bene il passaporto");
        }
    }
}
