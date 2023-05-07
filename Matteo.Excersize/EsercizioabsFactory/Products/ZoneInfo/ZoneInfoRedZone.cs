using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products.ZoneInfo
{
    class ZoneInfoRedZone : ProductFactory
    {
        public ZoneInfoRedZone(Europe europe)
        {
            Console.WriteLine($"{europe.Name} e' nella zona rossa");
        }
    }

}
