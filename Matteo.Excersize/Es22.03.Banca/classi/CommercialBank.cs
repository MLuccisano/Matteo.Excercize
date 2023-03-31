using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {
        StockMarket sm = new StockMarket("Wallstreet", "NY");
        Stocks stocks = new Stocks(STOCKS.TSLA, "TESLA", 100);
        CentralBank _centralbank;
        public Account _account;
        List<Account> _listAccounts;
        public CentralBank CentralBank { get => _centralbank; }
        internal List<Account> ListAccounts { get => _listAccounts; set => _listAccounts = value; }

        
        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank) : base(Name, RegisteredOffice, Country)
        {
            _centralbank = centralbank;
            //arrayAccount = new Account[0];
            ListAccounts = new List<Account>();
            
        }
        
        /*private void addAccount(Account account)
        {
            Account[] arrayAccountCopy = new Account[arrayAccount.Length + 1];
            Array.Copy(arrayAccount, arrayAccountCopy, arrayAccount.Length);
            arrayAccount = arrayAccountCopy;
            arrayAccount[cont] = account;
            cont++;
            
        }*/

        /*public void visualizeAccount(List<Account> dataAccount)
        {
            foreach (var account in dataAccount)
            {
                Console.WriteLine($"Name: {account.Client.Fullname}");
                foreach (var clientAccount in account.Client.Accounts)
                {
                    Console.WriteLine($"BankAccount: {clientAccount.BankAccount}\n");
                }                
            }
            Console.WriteLine("----------------------------------------\n");
        }*/

        //public Account account { get { return _account; }}

        public void createAccount(string FullName, string CF)
        {           
            _account = new Account(FullName, CF, this);
            ListAccounts.Add(_account);
            
        }                  
        public void removeAccount(Account account)
        {
            var result = ListAccounts.FindIndex(data => data.Equals(account));
            if (result > 0)
            {
                ListAccounts.RemoveAt(result);
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
