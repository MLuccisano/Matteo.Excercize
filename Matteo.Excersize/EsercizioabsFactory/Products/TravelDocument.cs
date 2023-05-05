using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class TravelDocument : IFactory
    {
        ZoneInfoFactory _zif;
        string _travelDocument;
        public TravelDocument(ZoneInfoFactory zif)
        {
            _zif = zif;
            choice();
        }
        public void choice()
        {
            switch (_zif.ColorZone.ToLower())
            {
                case "green zone": _travelDocument = string.Format($"Nella zona verde va bene il passaporto");
                    break;
                case "yellow zone": _travelDocument = string.Format($"Nella zona gialla serve il passaporto e un autocertificazione");
                    break;
                case "red zone": _travelDocument = string.Format($"Nella zona rossa serve il passaporto, l'autocertificazione e un tampone COVID negativo");
                    break;
            }            
        }
    }
}
