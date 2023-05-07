using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    class TravelDocumentRedZone : ProductFactory
    {
        public TravelDocumentRedZone()
        {
            Console.WriteLine("Nella zona rossa serve il passaporto, l'autocertificazione e un tampone COVID negativo");
        }

    }
}
