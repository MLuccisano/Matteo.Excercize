using System;
using System.Collections.Generic;

namespace Contatore_COVID_EUROPEO
{
    internal class Program
    {
        public delegate void TotalCovidCase();

        static void Main(string[] args)
        {

            List<string> countries = new List<string>() { "Italia", "Germania", "Francia", "Portogallo", "Spagna" };
            EMA ema = new EMA(countries);
            TotalCovidCase totalCovidCaseDelegate = ema.CalcTotalCovidCases;
            var random = new Random();

            foreach (var country in countries)
            {
                ema.UpdateCovidPositives(country, random.Next(1, 100000), totalCovidCaseDelegate);
            }

            ema.GetCountriesCovidPositives();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Positivi totali");
            Console.WriteLine(ema.TotalCovidPositives);

            ema.UpdateCovidPositives("Italia", random.Next(1, 100000), totalCovidCaseDelegate);
            Console.WriteLine("Positivi totali aggiornati");
            Console.WriteLine(ema.TotalCovidPositives);

        }
    }
}
