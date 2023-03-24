using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CentralBank : Bank, IFlowMoney, InoSwiftSystem
    {
        CommercialBankRussian _commercialBank;
        public CentralBank(string Name, string RegisteredOffice) : base(Name, RegisteredOffice)
        { 
        }
        private void addCommercialBank(CommercialBankRussian commercialBank)
        {
            _commercialBank = commercialBank;
        }

        public void createCommercialBankRussian(string name, string registeredOffice)
        {
            _commercialBank = new CommercialBankRussian(name, registeredOffice);
        }
        public CommercialBankRussian commercialBankRussian { get { return _commercialBank; } set { _commercialBank = value; } }

        public void transferMoney(Bank bankSender, Bank bankDestination)
        {
            if (bankSender is InoSwiftSystem && bankDestination is InoSwiftSystem)
            {
                    Console.WriteLine("You can transfer the money");                             
            }

            else Console.WriteLine("you cannot transfer the money");
            
        }

        public void notSwitftSystem()
        {
            throw new NotImplementedException();
        }
    }
}
