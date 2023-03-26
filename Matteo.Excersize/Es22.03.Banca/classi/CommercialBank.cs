using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {
        BankAccount _bankaccount;
        public CommercialBank(string Name, string RegisteredOffice, string Country) : base(Name, RegisteredOffice, Country)
        { 
        }

        public void CreateAccount(string Name, string Surname, int BankAccount)
        {
            _bankaccount = new BankAccount(Name, Surname, BankAccount);
            
        }

        public BankAccount bankaccount { get { return _bankaccount; }}

        public void removeAccount(BankAccount account)
        {
            account = null;
        }
    }
}
