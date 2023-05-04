using EsercizioabsFactory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Factory
{
    public class ticketFactory : abstractFactory
    {
        public override IFactory GetChoice(string name)
        {
            switch (name.ToUpper())
            {
                case "AIRPLANE": return new agencyAirplane();
                case "BUS": return new agencyBus();
                case "TRAIN": return new agencyTrain();
                default: return null;
            }   
        }
    }
}
