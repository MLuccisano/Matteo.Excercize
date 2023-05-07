using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products.ZoneInfo
{
    class ZoneInfoGreenZone : ProductFactory
    {
        public ZoneInfoGreenZone(Europe europe)
        {
            Console.WriteLine($"{europe.Name} e' nella zona verde");      
        }
    }
}
