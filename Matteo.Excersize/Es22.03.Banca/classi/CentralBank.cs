using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CentralBank : Bank
    {
        CommercialBank _commercialBank;
        public CentralBank(string Name, string RegisteredOffice, string Country) : base(Name, RegisteredOffice, Country)
        { 
        }
        public CommercialBank commercialBank { get { return _commercialBank; } set { _commercialBank = value; } }

        public void flowMoney(Bank bankSender, Bank bankDestination)
        {
            if (bankSender.Country == bankDestination.Country) Console.WriteLine("Transfer successful");
            else
            { 
            }
        }
    }
}
