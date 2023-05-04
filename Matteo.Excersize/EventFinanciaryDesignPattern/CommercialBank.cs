using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciaryDesignPattern
{
   internal class CommercialBank : CentralBank, IObserver
    {
        string _name;
        CentralBank _centralBank;
        string newCeoCentralBank;

        public CentralBank CentralBank { get => _centralBank; }
        public CommercialBank(string name, string fullName, CentralBank centralBank) : base(name, fullName)
        {
            _name = name;
            _centralBank = centralBank;
        }

        public void Update()
        {
            newCeoCentralBank = _centralBank.Ceo.FullName;
            Console.WriteLine($"NOTIFICA DA {_name.ToUpper()}: La banca centrale {_centralBank.NameBank} cambia il ceo da {Ceo.FullName} a {newCeoCentralBank}\n");
        }

    }
}
