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
        public Account _account;
        //Account[] arrayAccount;
        List<Account> _accounts;

        int cont;
        public CentralBank CentralBank { get => _centralbank; }
        //public Account[] ArrayAccount { get => arrayAccount; }
        public List<Account> Accounts { get => _accounts; }

        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank) : base(Name, RegisteredOffice, Country)
        {
            _centralbank = centralbank;
            //arrayAccount = new Account[0];
            _accounts = new List<Account>();
        }
        
        /*private void addAccount(Account account)
        {
            Account[] arrayAccountCopy = new Account[arrayAccount.Length + 1];
            Array.Copy(arrayAccount, arrayAccountCopy, arrayAccount.Length);
            arrayAccount = arrayAccountCopy;
            arrayAccount[cont] = account;
            cont++;
            
        }*/

        public void visualizeAccount(List<Account> dataAccount)
        {
            foreach (var account in dataAccount)
            {
                Console.WriteLine($"Name: {account.Client.Fullname}");
                Console.WriteLine($"BankAccount: {account.BankAccount}\n");
                Console.WriteLine($"CodAccount: {account.Client.CodClient}\n");
            }

            Console.WriteLine("----------------------------------------\n");
        }

        //public Account account { get { return _account; }}

        public void createAccount(string FullName, string CF)
        {
            var result = _accounts.FindIndex(data => data.Client.Cf.Equals(CF));
            if (result == -1)
            {
                _account = new Account(FullName, CF, this);
                _accounts.Add(_account);
            }
            else
            {
                _account = new Account(FullName, CF, this);
                _accounts.Insert(result, _account);
            } 
        }                  
        public void removeAccount(Account account)
        {
            var result = _accounts.FindIndex(data => data.Equals(account));
            if (result > 0)
            {
                _accounts.RemoveAt(result);
            }
            else Console.WriteLine($"il cliente {account.Client.Fullname} non esiste");
        }

        public override bool Transfer(Bank Destination)
        {
            CommercialBank bankDestination = (CommercialBank)Destination;

            if (this._centralbank.flowMoney(this, bankDestination)) return true;
            else return false;
        }
    }
}
