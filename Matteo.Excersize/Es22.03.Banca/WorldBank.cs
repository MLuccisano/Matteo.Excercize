using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    static class WorldBank
    {
        public static bool checkTransfer(CommercialBank bankSender, CommercialBank bankDestination)
        {

            if (bankSender.CentralBank is IswiftSystem && bankDestination.CentralBank is IswiftSystem)
            {
                Console.WriteLine("Transfer Successful");
                return true;
            } 
            else 
            {
                if (bankSender.CentralBank is not IswiftSystem) Console.WriteLine($"Transfer locked by the World Bank swiftsystem. The Bank {bankSender.Name} from {bankSender.Country} is under sanction");
                else Console.WriteLine($"Transfer locked by the World Bank swiftsystem. The Bank {bankDestination.Name} from {bankDestination.Country} is under sanction");
                return false;
            }
            
        }
    }
}
