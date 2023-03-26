using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CommercialBankItalian : Bank, IswiftSystem
    {
        Account _account;
        public CommercialBankItalian(string Name, string RegisteredOffice) : base(Name, RegisteredOffice)
        { 
        }

        public void CreateAccount(string Name, string Surname, int BankAccount)
        {
            _account = new Account(Name, Surname, BankAccount);
            
        }

        public string account { get { return _account.customer + " "+_account.BankAccount.ToString(); }}

        private void addAccount(Account account)
        {
            _account = account;
        }

        public void removeAccount(Account account)
        {
            account = null;
        }

        public void applySwift()
        {
            
        }
    }
}
