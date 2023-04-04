using TEST.OOP.BankAccount.Enum;
using TEST.OOP.BankAccount.Interfaces;

namespace TEST.OOP.BankAccount.Abstract
{
    public abstract class FinancialIntermediary
    {
        protected string _name;
        protected string _country;
        protected string _city;
        protected int Counter;
        protected int _code;
        Asset[] _assets; // Cerca per EURO

        public FinancialIntermediary(string city, string country, string name)
        {
            _city = city;
            _country = country;
            _name = name;
        }
        public class Asset
        {
            protected string Name { get; set; }
            protected FinancialIntermediary FinancialIntermediary { get; set; }
        }
        public class Fiat : Asset
        {
            public Fiat(FIAT fIAT)
            {

            }
        }

        protected virtual Asset BuyStock(STOCK STOCK, int Amount, StockMarket stockMarket)
        {
            
            return stockMarket.BuyStock(STOCK, Amount, stockMarket);
        }

        protected virtual Asset BuyCrypto(CRYPTO crypto, int Amount, CryptoExchange cryptoExchange)
        {
            // Qui dentro posso vedere il Metodo BuyStock() di StockMarket perche hanno la stessa linea gerarchica! 
            return cryptoExchange.BuyCrypto(crypto, Amount, cryptoExchange);
        }

    }
    public class StockIntermediary : FinancialIntermediary
    {
        protected override Asset BuyStock(STOCK STOCK, int Amount, StockMarket stockMarket)
        {
            // Qui dentro posso vedere il Metodo BuyStock() di StockMarket perche hanno la stessa linea gerarchica! 
            return stockMarket.BuyStock(STOCK, Amount, stockMarket);
        }
        public StockIntermediary(string city, string country, string name)
            : base(city, country, name)
        { }
    }
    public class StockMarket : StockIntermediary
    {
        public StockMarket(string city, string country, string name)
            : base(city, country, name)
        {

        }
        protected override Asset BuyStock(STOCK STOCK, int Amount, StockMarket stockMarket)
        {
            return new Stock(STOCK, 2);
        }
        internal class Stock : Asset
        {
            StockMarket _stockMarket;
            STOCK _stockTicker;
            public StockMarket StockMarket { get; }
            public decimal Price { get; set; } = 200M;
            public Stock(STOCK cRYPTO, int Amount) //  Visibile dall'esterno ma non istanziabile
            {
            }
        }
    }

    public class CryptoIntermediary : FinancialIntermediary
    {
        public CryptoIntermediary(string city, string country, string name) : base(city, country, name)
        { }
        protected override Asset BuyCrypto(CRYPTO crypto, int Amount, CryptoExchange cryptoExchange)
        {
            // Qui dentro posso vedere il Metodo BuyStock() di StockMarket perche hanno la stessa linea gerarchica! 
            return cryptoExchange.BuyCrypto(crypto, Amount, cryptoExchange);
        }
 
    }
    public class CryptoExchange : CryptoIntermediary 
    {
        public CryptoExchange(string city, string country, string name)
            : base(city, country, name)
        { }

        protected override Asset BuyCrypto(CRYPTO crypto, int Amount, CryptoExchange cryptoExchange)
        {
            return new Crypto(crypto, 3);
        }
        internal class Crypto : Asset
        {
            StockMarket _stockMarket;
            CRYPTO _cryptoTicker;
            public CryptoExchange cryptoExchange { get; }
            public decimal Price { get; set; } = 100M;
            public Crypto(CRYPTO crypto, int Amount) //  Visibile dall'esterno ma non istanziabile
            {
            }
        }

    }

}

