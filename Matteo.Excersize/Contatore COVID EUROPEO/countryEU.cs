using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contatore_COVID_EUROPEO.Program;

namespace Contatore_COVID_EUROPEO
{
    internal class CountryEU
    {
        string _name;
        int _covidPositives;

        public string Name { get => _name; set => _name = value; }
        public int CovidPositives { get => _covidPositives; set => _covidPositives = value; }

        public CountryEU(string name)
        {
            Name = name;
        }

        public void UpdateCovidPositives(int num, TotalCovidCase totalCovidCase)
        {
            CovidPositives = 0;
            CovidPositives = num;
            totalCovidCase();
        }
    }

}
