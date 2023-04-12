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
                bool result = this.Withdraw(amount, BankAccountDestination);
                if (result == true)
                {
                    this.Deposit(amount, BankAccountSender);
                    Console.WriteLine("Trasfert successful");
                } 
                else Console.WriteLine("Amount not transfered");
            }
            else Console.WriteLine("Amount not transfered");
        }

        

        public void buyStock(FinancialIntermediary financialIntermediary, STOCKS stocks, string name, decimal amount)
        {
            base.BuyStocks(financialIntermediary, stocks, name, amount);
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
            string dateLastMoviment = readLogs(bankAccount);
            try 
            {

                if (account.Withdraw(amount, dateMovimentNow, dateLastMoviment) == true && account.ListAsset[indexAsset].Amount > amount) // account.Withdraw is a method that return a bool value
                {

                    log = String.Format($"{dateMovimentNow}, {account.Client.Fullname}, {account.BankAccount}, - {amount} {Currency}, currency: {account.ListAsset[indexAsset].Amount} {Currency}\n");
                    writeLogs(log, @"f:\log\", "log.txt");
                    return true;
                }
                else
                {
                    log = String.Format($"{dateMovimentNow}, {account.Client.Fullname}, {account.BankAccount}, Withdraw locked. \n");
                    writeLogs(log, @"f:\log\", "log.txt");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine($"the BankAccount {bankAccount} haven't got enough money to withdraw");

            }
            return false;

        }
        #endregion

        #region Methods Write and Read Logs
        private void writeLogs(string Log, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                
            }
            else File.AppendAllText(Path.Combine(path, fileName), Log);
        }
        private string readLogs(int bankAccount)
        {
            var index = ListAccounts.FindIndex(account => account.BankAccount.Equals(bankAccount));
            string[] line = File.ReadAllLines(@"f:\log\log.txt");
            string[] logs = new string[line.Length / 5];
            Array.Reverse(line);
            try
            {
                for (int i = 0; i < line.Length; i++)
                {
                    string log = line[i].ToString();
                    logs = log.Split(",");
                    if (int.Parse(logs[2]) == bankAccount) return logs[0];
                    else continue;
                }
                
            }
            catch
            {
                Console.WriteLine($"the bankAccount {bankAccount} cannot to withdraw");
            }
            return null;
        }
        #endregion
    }
}
