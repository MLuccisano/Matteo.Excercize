using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {

        #region Variable
        StockMarket _stockMarket;
        CentralBank _centralbank;
        Account _account;
        List<Account> _listAccounts;
        fiat _currency;

        public CentralBank CentralBank { get => _centralbank; }
        public fiat Currency { get => _currency; }
        internal List<Account> ListAccounts { get => _listAccounts;}
        string log;
        string dateMovimentNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:FFF");
        #endregion

        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank, StockMarket stockMarket, fiat currency) : base(Name, RegisteredOffice, Country)
        {
            _stockMarket = stockMarket;
            _centralbank = centralbank;
            _listAccounts = new List<Account>();
            _currency = currency;
        }

        #region Create, remove and Visualize Account

        public void createAccount(string FullName, string CF, string dateofbirth, string culture)
        {           
            _account = new Account(FullName, CF, dateofbirth, this, culture);
            _listAccounts.Add(_account);
            
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
            foreach (var dataAccount in _listAccounts)
            {
                Console.WriteLine(
                    $"FullName: {dataAccount.Client.Fullname}\n" +
                    $"BankAccount: {dataAccount.BankAccount}");
                foreach (var dataAsset in dataAccount.ListAsset)
                {
                    Console.WriteLine($"{dataAsset.Name}: {dataAsset.Amount}\n");
                }

                Console.WriteLine("--------------------------------------------\n");
            }
        }
#endregion

        #region Operation: BuyStock, Deposit, Withdraw and transfer
        public override void Transfer(decimal amount, Bank Destination,int BankAccountSender, int BankAccountDestination)
        {
            CommercialBank bankDestination = (CommercialBank)Destination;

            if (_centralbank.flowMoney(this, bankDestination) == true)
            {
                Account account = ListAccounts.Find(account => account.BankAccount.Equals(BankAccountSender));
                account.payment(amount);
                this.Deposit(amount, BankAccountDestination);
                Console.WriteLine("Trasfert successful");
            }
            else Console.WriteLine("Amount not transfered");
        }

        public void buyStock(int bankAccount, STOCKS stocks, decimal amount)
        {
            if (_stockMarket.country.Equals(this.country))
            {
                try
                {
                    Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
                    var indexStocks = _stockMarket.ListStocks.FindIndex(listStock => listStock.Equals(stocks));                   
                    Asset _stock = base.BuyStocks(_stockMarket, _stockMarket.ListStocks[indexStocks], amount);
                    if (_stock != null)
                    {
                        account.payment(amount);
                        Stock stock = (Stock)_stock;
                        _account.addStockAsset(stock);
                    }
                }
                catch { Console.WriteLine($"the stock {stocks} doesn't exist at the stockmarket {_stockMarket.name}"); }
            }
            else Console.WriteLine($"You cannot buy any stocks from {_stockMarket.name}.");

        }
        public void Deposit(decimal amount,int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));
            account.Deposit(amount);
            log = String.Format($"{dateMovimentNow}, {account.Client.Fullname}, {account.BankAccount}, + {amount} {Currency}, currency: {account.ListAsset[indexAsset].Amount} {Currency}\n");
            writeLogs(log, @"f:\log\", "log.txt");          
        }

        public bool Withdraw(decimal amount, int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));

            if (account.Withdraw(amount, dateMovimentNow) == true) // account.Withdraw is a method that return a bool value
            {

                log = String.Format($"{dateMovimentNow} ,{account.Client.Fullname}, {account.BankAccount}, - {amount} {Currency}, currency: {account.ListAsset[indexAsset].Amount} {Currency}\n");
                writeLogs(log, @"c:\log\", "log.txt");
                return true;
            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {account.Client.Fullname}, {account.BankAccount}, Withdraw locked. \n");
                writeLogs(log, @"C:\log\", "log.txt");
                return false;
            }
        }
            

        
        #endregion

        #region Methods WriteLogs
        private void writeLogs(string Log, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                
            }
            else File.AppendAllText(Path.Combine(path, fileName), Log);
        }

        public void visualizeStockAcquired(int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));

            foreach (var stock in account.ListAsset)
            {
                if (stock is Stock) Console.WriteLine(stock.Name);
                else continue;
            }
        }
        #endregion
    }
}
