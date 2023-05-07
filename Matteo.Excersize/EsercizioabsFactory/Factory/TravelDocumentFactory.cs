using EsercizioabsFactory.Products.ZoneInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class TravelDocumentFactory : IFactory
    {
        ZoneInfoFactory _zif;
        public TravelDocumentFactory(ZoneInfoFactory zif)
        {
            _zif = zif;
            choice();
        }
        public ProductFactory choice()
        {
            ProductFactory zifChoice = _zif.choice();
            if (zifChoice is ZoneInfoGreenZone) return new TravelDocumentGreenZone();
            else if (zifChoice is ZoneInfoYellowZone) return new TravelDocumentYellowZone();
            else return new TravelDocumentRedZone();
        }
    }
}
