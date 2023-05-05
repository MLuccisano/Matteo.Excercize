using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioabsFactory
{
    public class Europe
    {
        string _name;
        int _covidPositive;

        public int CovidPositive { get => _covidPositive; set => _covidPositive = value; }
        public string Name { get => _name; set => _name = value; }

        public Europe(string name, int covidPositive)
        {
            Name = name;
            _covidPositive = covidPositive;
        }

        
    }
}
