using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Products
{
    public class ZoneInfoFactory : IFactory
    {
        string _colorZone;
        Europe _europe;
        public ZoneInfoFactory(Europe europe)
        {
            _europe = europe;
            choice();
        }

        public string ColorZone { get => _colorZone; set => _colorZone = value; }

        public void choice()
        {
            switch (_europe.CovidPositive)
            {
                case <= 10000:
                    Console.WriteLine($"{ _europe.Name} is green zone");
                     ColorZone = "Green Zone";
                    break;

                case <= 30000:
                    Console.WriteLine($"{ _europe.Name} is yellow zone");
                     ColorZone = "yellow Zone";
                    break;

                case > 30000:
                    Console.WriteLine($"{ _europe.Name} is red zone");
                     ColorZone = "red Zone";
                    break;
            }
        }
    }
}
