using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciary
{
    class CryptoExchange : CentralBank
    {
        string name;
        public CryptoExchange(string nameIF, string fullName) : base(nameIF, fullName)
        {
            name = nameIF;
        }

        public override void EventChangeCeo(object sender, ChangeCeoEventArgs e)
        {
            var nameCentralBank = sender.GetType().GetProperty("NameCentralBank").GetValue(sender);
            Console.WriteLine($"NOTIFICA {name.ToUpper()}:La banca centrale {nameCentralBank} cambia il ceo da {Ceo.FullName} a {e.FullName}\n");
        }
    }
}
