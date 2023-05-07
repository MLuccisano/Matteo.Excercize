using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    class TravelDocumentYellowZone : ProductFactory
    {
        public TravelDocumentYellowZone()
        {
            Console.WriteLine("Nella zona gialla serve il passaporto e un autocertificazione");
        }
    }
}
