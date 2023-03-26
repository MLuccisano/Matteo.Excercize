using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    static class WorldBank
    {
        public static void checkTransfer(Bank bankSender, Bank bankDestination)
        {
            if (bankSender is IswiftSystem && bankDestination is IswiftSystem) Console.WriteLine("Transfer Successful");
            if (bankSender is not IswiftSystem) Console.WriteLine($"Transfer locked by the World Bank swiftsystem. The Bank {bankSender.Name} from {bankSender.Country} is under sanction"); 
            else Console.WriteLine($"Transfer locked by the World Bank swiftsystem. The Bank {bankDestination.Name} from {bankDestination.Country} is under sanction");
        }
    }
}
