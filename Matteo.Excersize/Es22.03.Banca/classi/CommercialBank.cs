using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {
        CentralBank _centralbank;
        Account _account;
        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank) : base(Name, RegisteredOffice, Country)
        {
            _centralbank = centralbank;
        }

        public void CreateAccount(string Name, string Surname, int BankAccount)
        {
            _account = new Account(Name, Surname, BankAccount, this);
            
        }

        public Account account { get { return _account; }}

        public void removeAccount(Account account)
        {
            account = null;
        }
    }
}
