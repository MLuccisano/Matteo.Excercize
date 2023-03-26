using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    public class WorldBank : Bank
    {
        public WorldBank(string Name, string RegisteredOffice, string Country) : base(Name, RegisteredOffice, Country)
        { 
        }
        public void FlowMoney(Bank bankSender, Bank bankDestination)
        {
            if (bankSender is IswiftSystem && bankDestination is IswiftSystem) Console.WriteLine("Transfer successful");
            else Console.WriteLine("Transfer locked by a WorldBank Swiftsystem.");
        }

    }
}
