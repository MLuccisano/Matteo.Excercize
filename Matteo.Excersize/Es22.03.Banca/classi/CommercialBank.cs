using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {
        StockMarket _stockMarket;
        CentralBank _centralbank;
        Account _account;
        List<Account> _listAccounts;
        fiat _moneta;
        public CentralBank CentralBank { get => _centralbank; }
        public fiat Moneta { get => _moneta; }
        internal List<Account> ListAccounts { get => _listAccounts; set => _listAccounts = value; }


        
        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank, StockMarket stockMarket, fiat moneta) : base(Name, RegisteredOffice, Country)
        {
            _stockMarket = stockMarket;
            _centralbank = centralbank;
            //arrayAccount = new Account[0];
            ListAccounts = new List<Account>();
            _moneta = moneta;
        }
        

        public void createAccount(string FullName, string CF, string dateofbirth, string culture)
        {           
            _account = new Account(FullName, CF, dateofbirth, this, culture);
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

        public void visualizeAccount()
        {
            foreach (var dataAccount in ListAccounts)
            {
                Console.WriteLine(
                    $"FullName: {dataAccount.Client.Fullname}\n " +
                    $"BankAccount: {dataAccount.BankAccount}\n ");
                foreach (var dataAsset in dataAccount.ListAsset)
                {
                    Console.WriteLine($"{dataAsset.Name}: {dataAsset.Amount}");
                }                                      
            }
        }

        public override bool Transfer(Bank Destination)
        {
            CommercialBank bankDestination = (CommercialBank)Destination;

            if (this._centralbank.flowMoney(this, bankDestination)) return true;
            else return false;
        }

        public void buyStock(FinancialIntermediary financialIntermediary, STOCKS stocks, string name, decimal amount)
        {
            base.BuyStocks(financialIntermediary, stocks, name, amount);
        }
        public void Deposit(decimal amount,int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            account.Deposit(amount);
            
        }
    }
}
