using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciary
{
    class commercialBank : CentralBank
    {
        string _name;
        public commercialBank(string nameIF, string fullName) : base(nameIF, fullName)
        {
            _name = nameIF;    
        }

        public override void EventChangeCeo(object sender, ChangeCeoEventArgs e)
        {
            var nameCentralBank = sender.GetType().GetProperty("NameCentralBank").GetValue(sender);
            Console.WriteLine($"NOTIFICA DA {_name.ToUpper()}: La banca centrale {nameCentralBank} cambia il ceo da {Ceo.FullName} a {e.FullName}\n");
        }
    }
}
