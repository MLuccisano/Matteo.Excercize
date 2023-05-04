using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory.Factory
{
    public class ClientChoiceFactory
    {
        public static abstractFactory GetFactory(string nameFactory)
        {
            switch (nameFactory.ToUpper())
            {
                case "COVID": return new CovidFactory();
                case "TICKET": return new ticketFactory();
                default:
                    Console.WriteLine($"{nameFactory} doesn't exist factory");
                    return null;
            }
        }
    }
}
