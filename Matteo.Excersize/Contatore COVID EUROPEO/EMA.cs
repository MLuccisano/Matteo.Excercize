using System;
using System.Collections.Generic;
using static Contatore_COVID_EUROPEO.Program;

namespace Contatore_COVID_EUROPEO
{
    internal class EMA
    {
        List<CountryEU> _countryList;
        int _totalCovidPositives;

        public List<CountryEU> CountryList { get => _countryList; set => _countryList = value; }
        public int TotalCovidPositives 
        { 
            get => _totalCovidPositives;
            set
            {
                if (_totalCovidPositives != value)
                {
                    COVIDeventArg e = new COVIDeventArg(value);
                }
            }
                
        }

        public EMA(List<string> countryNames)
        {
            CountryList = new List<CountryEU>();

            foreach (string countryName in countryNames)
            {
                CountryEU country = new CountryEU(countryName);
                CountryList.Add(country);
            }

        }

        public void CalcTotalCovidCases()
        {
            TotalCovidPositives = 0;

            foreach (CountryEU country in CountryList)
            {
                TotalCovidPositives += country.CovidPositives;
            }
        }

        public void UpdateCovidPositives(string countryName, int num, TotalCovidCase totalCovidCase)
        {
            CountryEU country = CountryList.Find(x => x.Name == countryName);
            country.UpdateCovidPositives(num, totalCovidCase);
        }

        public void GetCountriesCovidPositives()
        {
            foreach (CountryEU country in CountryList)
            {
                Console.WriteLine(country.CovidPositives);
            }
        }
    }
}
