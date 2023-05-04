using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsercizioabsFactory.Products;

namespace EsercizioabsFactory.Factory
{
    public class CovidFactory : abstractFactory
    {
        public override IFactory GetChoice(string name)
        {
            switch (name.ToUpper())
            {
                case "ZIF": return new ZoneInfoFactory();
                case "TRAVEL DOCUMENT": return new TravelDocument();
                default: return null;
            }
        }
    }
}
