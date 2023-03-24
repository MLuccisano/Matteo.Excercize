using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    class SwiftCentralBank : Bank, IswiftSystem, IFlowMoney
    {
        CommercialBankItalian _commercialBank;

        public SwiftCentralBank(string Name, string RegisteredOffice) : base(Name, RegisteredOffice)
        { 
            
        }

        public CommercialBankItalian commercialBankItalian { get { return _commercialBank; } set { _commercialBank = value; } }

        private void addCommercialBank(CommercialBankItalian commercialBank)
        {
            _commercialBank = commercialBank;
        }

        public void createCommercialBankItalian(string name, string registeredOffice)
        {
            _commercialBank = new CommercialBankItalian(name, registeredOffice);
        }

        public void applySwift()
        {
            Console.WriteLine("This bank has got a swift system");
        }
        public void transferMoney(Bank bankSender, Bank bankDestination)
        {
            if (bankSender is IswiftSystem)
            {
                if (bankDestination is IswiftSystem)
                {
                    Console.WriteLine("You can transfer the money");
                }
                else Console.WriteLine("you cannot transfer the money");
            }

            else Console.WriteLine("you cannot transfer the money");

        }


    }
}
