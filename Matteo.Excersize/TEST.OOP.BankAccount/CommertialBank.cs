using System;
using System.Linq;
using TEST.OOP.BankAccount.Abstract;
using TEST.OOP.BankAccount.Enum;
using TEST.OOP.BankAccount.Interfaces;
using TEST.OOP.BankAccount.Utils;


namespace TEST.OOP.BankAccount
{
    class CommertialBank : FinancialIntermediary
    {
        private CentralBank _centralBank;
        Account _account;
        Client[] _clienti;
        StockMarket _stockMarket;
        CryptoExchange _cryptoExchange;
        int Amount;
        public Account account { get => _account; }
        public CentralBank CentralBank { get => _centralBank; }
        public CommertialBank(string City, string Country, string Name, CentralBank Bank, StockMarket stockMarket, CryptoExchange cryptoExchange) : base( City,Country, Name)
        {
            _centralBank = Bank;
            _country = Country;
            _name = Name;
            _code = new Random().Next(10000, 1000000);
            _clienti = new Client[0];
            _stockMarket = stockMarket; //
            _cryptoExchange = cryptoExchange;

        }
        public void BuyStock(STOCK stocks, int Amount)
        {
            base.BuyStock(stocks, Amount, _stockMarket);
        }

        public void BuyCrypto(CRYPTO crypto, int Amount)
        {
            base.BuyCrypto(crypto, Amount, _cryptoExchange);
        }
        /* public void BuyStock(STOCK sTOCK, int Amount)
         {
             // _stockMarket.BuyStock()   ->>> NON POSSO vedere BuyStock() dalla classe StockMarket perchè è accessibile solo dalla sua gerarchia
             base.BuyStock(STOCK.TESLA, Amount, _stockMarket); // Chiama BuyStock dalla SuperClasse, cioè "StockIntermediary" 
         }*/



        #region 

        public void CreateAccount(string ClientName, string ClientCF)
        {
            // Cerca nella lista dei clienti,
            var cliente = this._clienti.Where(c => c.Cf == ClientCF).FirstOrDefault();

            if (cliente != null)
            {
                new Account(cliente, this);// --> se non esiste crea un nuovo cliente
            }
            else
            {
                Client newCliente = new Client(ClientName, ClientCF);
                _account = new Account(newCliente, this);// --> se non esiste  crea un nuovo cliente 
                this.AddCliente(newCliente);
            }
        }
        //public override bool Transfer(Bank to, FIATDespositRequest data)
        //{

        //    // CommertialBank transferFrom = (CommertialBank) from;
        //    CommertialBank transferTo = (CommertialBank)to;

        //    if (this._centralBank.CheckTransfer(this, transferTo, data))
        //    {
        //        /*  
        //           Prima di procedere con il versamento, verificare che l'ammontare da accreditare è stato effettivamente scalato dal conto del versatore
        //           Quindi  avere una copia dello stato del conto prima di scalere i soldi per  poter confrontare che il prelievo è andato a buon fine.

        //         */


        //        // stato conto prima
        //        this.account.WithdrawFIAT(data._amount);
        //        // confronto le due cifr dopo il prelievo. 
        //        Utility.GetAccountInfo(ConsoleColor.Red, this, false, data);

        //        transferTo.account.DepositFIAT(data._amount);
        //        Utility.GetAccountInfo(ConsoleColor.Green, transferTo, true, data);


        //        Console.BackgroundColor = ConsoleColor.Green;
        //        Console.ForegroundColor = ConsoleColor.Black;
        //        Console.WriteLine($"The  amount {data._amount} from the account {data._accountfrom} from the Bank {this.Name} to " +
        //            $"account {data._accountTo} of from the Bank {to.Name} has been made! ");
        //        Console.ResetColor();

        //        return true;
        //    }
        //    return false;

        //}
        public void DepositFiat(decimal Amount)
        {
            // Check Client // è biondo! 
            _account.DepositFIAT(Amount);
        }
        public void DepositCrypto(decimal Amount)
        {
            _account.DepositCrypto(Amount);
        }
       /* public void InvestInStock(STOCK ticker, int Amount)
        {
            for (int i = 0; i <= Amount; i++)
            {
                var stk = _stockMarket.BuyStock(ticker);
                _account.InvestInStoks(stk);
            }
        }*/
        public void WithdrawFIAT(decimal Amount)
        {
            _account.WithdrawFIAT(Amount);
        }
        public void WithdrawCrypto(decimal Amount)
        {
            this._account.WithdrawCrypto(Amount);
        }
        public void SellStoks(decimal Amount)
        {
            this._account.SellStoks(Amount);
        }
        public void AddCliente(Client client)
        {
            // Aggiugi alla lista dei clienti 
        }

 

        //public  Asset BuyAsset(STOCK sTOCK) { return null; }        
        //public  Asset BuyAsset(CRYPTO cRYPTO) { return null; }
        //protected override Asset SellAsset(Asset[] asset) { return null; }
        public class Client
        {
            string _name;
            string _cf;
            Account _account;
            long _clientId;

            public Client(string ClientName, string ClientCF)
            {
                _cf = ClientCF;
                _name = ClientName;
                _clientId = new Random().Next(10000, 100000);
            }
            public string Name { get => _name; set => _name = value; }
            public long ClientId { get => ClientId; }
            public string Cf { get => _cf; }

            public void AssociaAccount(Account account)
            {
                _account = account;
            }
            public void DissociaAccount(Account account)
            {
                _account = null;
            }

        }
        public class Account
        {
            CommertialBank _commertialBank;
            public Client client;
            public long AccountNumber { get; }
            Asset[] assets;
            decimal _interests;
            int assetsCounter;
            //decimal _balance;

            //public override decimal AmountInEuro { get => StockAmount * _stockPrice; }
            //public int StockAmount { get { return _stocks.Length; } }
            //public int FIATAmount { get { return _stocks.Length; } }
            //public int CrytoAmount { get { return _stocks.Length; } }
            //public decimal Amount { get { return _fiat.AmountInEuro + _crypto.AmountInEuro + _stocks.AmountInEuro; } }
            public decimal Balance { get { return CalcAmount() + calcInterests(); } }

            //public Account(string ClientName, string ClientCF, CommertialBank commertialBank)
            //{
            //    _commertialBank = commertialBank;
            //    client = new Client(ClientName, ClientCF, this);
            //    AccountNumber = new Random().Next(10000, 1000000);
            //    assets = new Asset[0];

            //}
            public Account(Client Cliente, CommertialBank commertialBank)
            {
                _commertialBank = commertialBank;
                client = Cliente;
                AccountNumber = new Random().Next(10000, 1000000);
                assets = new Asset[0];
            }
            decimal calcInterests()
            {
                return _interests = (CalcAmount() / 100) * _commertialBank.CentralBank._interestRate;
            }
            decimal CalcAmount()
            {
                return 0M;
                // return _fiat.AmountInEuro + _crypto.AmountInEuro + _stocks.AmountInEuro;
            }
            public void DepositFIAT(decimal Amount)
            {
                // this._fiat.EuroAmount += Amount;
            }
            public void DepositCrypto(decimal Amount)
            {
                // aggiungi crypto alla lista 
            }
           /* public void InvestInStoks(Stock stock)
            {
                // aggiungi Stock alla lista  

                if (assetsCounter >= assets.Length)
                {
                    /// Crea nuovo spazio 
                }
                else
                {
                    assets[assetsCounter] = stock;
                    assetsCounter++;
                }

            }*/
            public void WithdrawFIAT(decimal Amount)
            {
                // this._fiat.EuroAmount -= Amount;
            }
            public void WithdrawCrypto(decimal Amount)
            {
                // this._crypto.CryptoAmount -= Amount;
            }
            public void SellStoks(decimal Amount)
            {
                // this._stocks.StockAmount -= Amount;
            }


            //public abstract class Asset
            //{
            //    Account _account;
            //    public abstract decimal AmountInEuro { get; }
            //    public Asset(Account Account)
            //    {
            //        _account = Account;
            //    }

            //}
            //public class Fiat : Asset
            //{
            //    public decimal EuroAmount;
            //    public decimal GbpAmount;


            //    decimal _euroPrice = 1;
            //    decimal _gbpPrice = 0.89M;
            //    public override decimal AmountInEuro { get => EuroAmount + (GbpAmount * _gbpPrice); } // Converti in EURO. Per esempio, se ho altre FIAT come Dollari, Yen , Sterline 
            //    // public decimal FiatAmount { get => _fiatAmount; set => _fiatAmount = value; }
            //    public Fiat(Account Account) : base(Account)
            //    {

            //    }
            //}
            //public class Crypto : Asset
            //{
            //    decimal _cryptoAmount;
            //    decimal _cryptoPrice = 28000;
            //    public override decimal AmountInEuro { get => _cryptoAmount * _cryptoPrice; }
            //    public decimal CryptoAmount { get => _cryptoAmount; set => _cryptoAmount = value; }

            //    public Crypto(Account Account) : base(Account)
            //    {

            //    }
            //}

        }
        #endregion

    }



}

