using EsercizioabsFactory.Products.ZoneInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class ZoneInfoFactory : IFactory
    {
        Europe _europe;
        public ZoneInfoFactory(Europe europe)
        {
            _europe = europe;
        }

        public ProductFactory choice()
        {
            switch (_europe.CovidPositive)
            {
                case <= 10000: return new ZoneInfoGreenZone(_europe);

                case <= 30000: return new ZoneInfoYellowZone(_europe);

                case > 30000: return new ZoneInfoRedZone(_europe);
            }
        }
    }
}
