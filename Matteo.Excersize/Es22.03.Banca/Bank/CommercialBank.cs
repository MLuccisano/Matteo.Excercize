using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;
using Es22._03.Banca.Utility;

namespace Es22._03.Banca
{
    internal class CommercialBank : Bank
    {

        #region Variable
        StockMarket _stockMarket;
        CryptoExhange _cryptoExhange;
        CentralBank _centralbank;
        Account _account;
        List<Account> _listAccounts;
        fiat _currency;
        string path = @"C:\log\";
        string fileName = "log.txt";

        public CentralBank CentralBank { get => _centralbank; }
        public fiat Currency { get => _currency; }
        internal List<Account> ListAccounts { get => _listAccounts;}
        string log;
        string dateMovimentNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:FFF");
        #endregion

        public CommercialBank(string Name, string RegisteredOffice,string Country, CentralBank centralbank, StockMarket stockMarket, CryptoExhange cryptoExhange, fiat currency) : base(Name, RegisteredOffice, Country)
        {
            _stockMarket = stockMarket;
            _centralbank = centralbank;
            _listAccounts = new List<Account>();
            _currency = currency;
            _cryptoExhange = cryptoExhange;
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
            else Console.WriteLine($"The client {account.ClientFullname} doesn't exist.");
        }

        public void visualizeAccount()
        {
            foreach (var dataAccount in _listAccounts)
            {
                Console.WriteLine(
                    $"FullName: {dataAccount.ClientFullname}\n" +
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

            Account accountSender = ListAccounts.Find(account => account.BankAccount.Equals(BankAccountSender));
            var indexAssetSender = accountSender.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));

            Account accountDestination = bankDestination.ListAccounts.Find(account => account.BankAccount.Equals(BankAccountDestination));
            var indexAssetDestination = accountDestination.ListAsset.FindIndex(asset => asset.Name.Equals(bankDestination.Currency.ToString()));

            if (_centralbank.flowMoney(this, bankDestination) == true)
            {
                decimal amountExchanged = CurrencyConverter.exchangeRateFiat(this.Currency, bankDestination.Currency) * amount;


                if (accountSender.ListAsset[indexAssetSender].Amount > amount)
                {
                    switch (accountSender.payment(amount))
                    {
                        case true:
                            if (accountDestination.DepositFiat(amountExchanged))
                            {
                                log = String.Format($"{dateMovimentNow}, {accountSender.ClientFullname}, {accountSender.BankAccount}, Transfer: {amount} {Currency} to {accountDestination.ClientFullname} ({accountDestination.BankAccount}) Bank Destination: {bankDestination.Name}, Bilance: {accountSender.ListAsset[indexAssetSender].Amount} {Currency} \n");
                                LogSystem.writeLogs(log, path, fileName);

                                log = String.Format($"{dateMovimentNow}, {accountDestination.ClientFullname}, {accountDestination.BankAccount}, Deposit: {amountExchanged} {bankDestination.Currency}, currency: {accountDestination.ListAsset[indexAssetDestination].Amount} {bankDestination.Currency}\n");
                                LogSystem.writeLogs(log, path, fileName);

                                Console.WriteLine($"Trasfert successful: {this.Name} transfer {amount} {this.Currency} to {bankDestination.name} {amountExchanged} {bankDestination.Currency}.");
                            }
                            else
                            {
                                log = String.Format($"{dateMovimentNow}, {bankDestination.Name}, {accountDestination.ClientFullname}, {accountDestination.BankAccount}, Deposit locked: Account locked for exceeded limit witdraw month. \n");
                                LogSystem.writeLogs(log, path, fileName);
                            }
                            break;
                        case false:
                            log = String.Format($"{dateMovimentNow}, {Name}, {accountSender.ClientFullname}, {accountSender.BankAccount}, Transfer locked: Account locked for exceeded limit witdraw month. \n");
                            LogSystem.writeLogs(log, path, fileName);
                            break;
                    }

                }
                else
                {
                    log = String.Format($"{dateMovimentNow}, {Name}, {accountSender.ClientFullname}, {accountSender.BankAccount}, Transfer locked: Not enough money \n");
                    LogSystem.writeLogs(log, path, fileName);
                }

            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {accountSender.ClientFullname}, {accountSender.BankAccount}, Transfer locked by a swift system \n");
                LogSystem.writeLogs(log, path, fileName);
            }
        }

        public void buyStock(int bankAccount, STOCKS stocks, decimal amount)
        {
            if (_stockMarket.country.Equals(this.country))
            {
                try
                {
                    Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
                    var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));
                    var indexStocks = _stockMarket.ListStocks.FindIndex(listStock => listStock.Equals(stocks));
                    decimal bilance = account.ListAsset[indexAsset].Amount;
                    Asset stock = base.BuyStocks(_stockMarket, _stockMarket.ListStocks[indexStocks], amount);

                    if (bilance > amount)
                    {
                        if (stock != null)
                        {
                            if (account.payment(amount))
                            {
                                account.addStockAsset(stock);
                                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Stock Aquired: {amount} {Currency} of {stock.Name} from stockmarket {_stockMarket.name} ({_stockMarket.country}) \n");
                                LogSystem.writeLogs(log, path, fileName);
                                Console.WriteLine($"{account.ClientFullname} has bought  {amount} {Currency} of stock {stocks}");
                            }
                            else
                            {
                                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Stock purchase blocked: Account locked for exceeded limit withdraw month . \n");
                                LogSystem.writeLogs(log, path, fileName);
                            }

                        }
                    }
                    else
                    {
                        log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Stock purchase blocked: Not enough Money . \n");
                        LogSystem.writeLogs(log, path, fileName);
                    }
                }
                catch { Console.WriteLine($"the stock {stocks} doesn't exist at the stockmarket {_stockMarket.name} ({_stockMarket.country})"); }
            }
            else Console.WriteLine($"You cannot buy any stocks from {_stockMarket.name} ({_stockMarket.country}).");
        }
                        
        public void DepositFIAT(decimal amount,int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));

            if (account.DepositFiat(amount) == true)
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Deposit: {amount.ToString("F")} {Currency}, Bilance: {account.ListAsset[indexAsset].Amount.ToString("F")} {Currency}\n");
                LogSystem.writeLogs(log, path, fileName);
            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Deposit locked. \n");
                LogSystem.writeLogs(log, path, fileName);
            }
        
        }

        public void WithdrawFIAT(decimal amount, int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));
            decimal bilance = account.ListAsset[indexAsset].Amount;

            if (bilance > amount)
            {
                if (account.WithdrawFiat(amount, dateMovimentNow) == true) // account.Withdraw is a method that return a bool value
                {

                    log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Withdraw: {amount} {Currency}, Bilance: {account.ListAsset[indexAsset].Amount} {Currency}\n");
                    LogSystem.writeLogs(log, path, fileName);
                    Console.WriteLine($"{account.ClientFullname} has withdrew {amount} {Currency}");
                }
                else
                {
                    log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Withdraw locked: Account locked for exceeded limit withhdraw month. \n");
                    LogSystem.writeLogs(log, path, fileName);
                    Console.WriteLine($"{account.ClientFullname} has withdrew {amount} {Currency} and the your accout is locked");
                }
            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Withdraw locked: Not enough money \n");
                LogSystem.writeLogs(log, path, fileName);
            }

            
        }

        public void buyCrypto(decimal amount, CRYPTO cryptos,int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));           
            var indexCrypto = _cryptoExhange.ListCrypto.FindIndex(listCrypto => listCrypto.Equals(cryptos));

            decimal bilance = account.ListAsset[indexAsset].Amount;

            if (bilance >= amount)
            {
                if (account.payment(amount))
                {
                    Asset crypto = base.BuyCrypto(_cryptoExhange, _cryptoExhange.ListCrypto[indexCrypto]);
                    int indexCryptoAsset = account.cryptoAsset(cryptos);
                    if (indexCryptoAsset != -1) OperationBuyCrypto(account, cryptos, amount, indexAsset,indexCryptoAsset);
                    else
                    {
                        account.addCryptoAsset(crypto);
                        indexCryptoAsset = account.cryptoAsset(cryptos);
                        OperationBuyCrypto(account, cryptos, amount, indexAsset, indexCryptoAsset);
                    }
                    
                }
                else 
                {
                    log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Crypto purchase blocked: Account locked for exceeded limit witdraw month. \n");
                    LogSystem.writeLogs(log, path, fileName);
                }

            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Crypto purchase blocked: Not enough money \n");
                LogSystem.writeLogs(log, path, fileName);
            }

        }

        public void SellCrypto(decimal amount, CRYPTO cryptos, int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));
            var indexCrypto = _cryptoExhange.ListCrypto.FindIndex(listCrypto => listCrypto.Equals(cryptos));

            int indexCryptoAsset = account.cryptoAsset(cryptos);
            decimal bilanceCrypto = account.ListAsset[indexCryptoAsset].Amount;

            if (bilanceCrypto >= amount)
            {
                decimal exchangeCryptoToFiat = CurrencyConverter.exchangeRateCryptoToFiat(cryptos, Currency)*amount;
                base.SellCrypto(_cryptoExhange, _cryptoExhange.ListCrypto[indexCrypto], amount);
                DepositFIAT(exchangeCryptoToFiat, bankAccount);
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Crypto Selled: {amount} {cryptos} ({exchangeCryptoToFiat} {Currency}) from cryptoExchange {_cryptoExhange.name} ({_cryptoExhange.country}), Bilance: {account.ListAsset[indexAsset].Amount.ToString("F")} {Currency}\n");
                LogSystem.writeLogs(log, path, fileName);
                Console.WriteLine($"{account.ClientFullname} has sold the crypto {amount} {cryptos} ({exchangeCryptoToFiat} {Currency})");
            }
        }

        public void SellStocks(STOCKS stocks, int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            var indexAsset = account.ListAsset.FindIndex(asset => asset.Name.Equals(Currency.ToString()));
            Asset stock = account.searchStockAsset(stocks);
            if (stock != null)
            {             
                base.SellStocks(_stockMarket, stock);
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount} Stock Sold: {stock.Name} {stock.Amount} {Currency}");
                LogSystem.writeLogs(log, path, fileName);
                DepositFIAT(stock.Amount, bankAccount);
                Console.WriteLine($"{account.ClientFullname} has sold the stock {stocks})");
            }
            else
            {
                log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount} Stock Sold failed: StockMarket is close \n");
                LogSystem.writeLogs(log, path, fileName);
            }

        }
        #endregion

        private void OperationBuyCrypto(Account account, CRYPTO cryptos, decimal amount, int indexAsset,int indexCryptoAsset)
        {
            decimal exchangeFiatToCrypto = CurrencyConverter.exchangeRateFiatToCrypto(this.Currency, cryptos) * amount;
            _cryptoExhange.DepositCrypto(exchangeFiatToCrypto);
            log = String.Format($"{dateMovimentNow}, {Name}, {account.ClientFullname}, {account.BankAccount}, Crypto Aquired: {exchangeFiatToCrypto} {cryptos} ({amount} {Currency}) from cryptoExchange {_cryptoExhange.name} ({_cryptoExhange.country}), Bilance: {account.ListAsset[indexAsset].Amount} {Currency}, Bilance Crypto {account.ListAsset[indexCryptoAsset].Amount}\n");
            LogSystem.writeLogs(log, path, fileName);
            Console.WriteLine($"{account.ClientFullname} has bought {exchangeFiatToCrypto} {cryptos} ({amount} {Currency})");
        }

        public void visualizeStockAcquired(int bankAccount)
        {
            Account account = ListAccounts.Find(account => account.BankAccount.Equals(bankAccount));
            _stockMarket.visualizeStockAcquired(account);
        }
        
    }
}
