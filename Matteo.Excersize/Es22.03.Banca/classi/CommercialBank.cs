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
        Account[] arrayAccount;
        int cont;
        public CentralBank CentralBank { get => _centralbank; }
        public Account[] ArrayAccount { get => arrayAccount; }
        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank) : base(Name, RegisteredOffice, Country)
        {
            _centralbank = centralbank;
            arrayAccount = new Account[0];
        }
        
        public void addAccount(Account account)
        {
            Account[] arrayAccountCopy = new Account[arrayAccount.Length + 1];
            Array.Copy(arrayAccount, arrayAccountCopy, arrayAccount.Length);
            arrayAccount = arrayAccountCopy;
            arrayAccount[cont] = account;
            cont++;
        }

        public void visualizeAccount(Account[] dataAccount)
        {
            foreach (var account in dataAccount)
            {
                Console.WriteLine($"Name: {account.Customer.Name}");
                Console.WriteLine($"Surmame: {account.Customer.Surname}");
                Console.WriteLine($"BankAccount: {account.BankAccount}\n");
                
            }

            Console.WriteLine("----------------------------------------\n");
        }

        //public Account account { get { return _account; }}

        public Account createAccount(string Name, string Surname)
        {
            _account = new Account (Name, Surname, this);
            return _account;
        }
        public void removeAccount(Account account)
        {
            account = null;
        }

        public override bool Transfer(Bank Destination)
        {
            CommercialBank bankDestination = (CommercialBank)Destination;

            if (this._centralbank.flowMoney(this, bankDestination)) return true;
            else return false;
        }
    }
}
