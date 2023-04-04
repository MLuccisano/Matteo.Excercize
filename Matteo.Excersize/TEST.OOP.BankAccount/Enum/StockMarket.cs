using System.Linq;

namespace TEST.OOP.BankAccount.Enum
{

    public enum FIAT
    {
        EURO,
        USD,
        YEN,
        GBP,
        CHF
    }
    public enum STOCK
    {
        TESLA,
        META,
        APL,
        BMW,
        HONDA
    }
    public enum CRYPTO
    {
        BTC,
        ETH,
        USDC,
        TETHER,
        SHIBA
    }

    //class Stock
    //{
    //    public STOCK _sTOCK;
    //    public string Name { get; set; } = "APPLE inc. ";
    //    public Stock(string Name, STOCK sTOCK)
    //    {
    //        Name = Name;
    //        _sTOCK = sTOCK;
    //    }
    //}

    //class StockMarket // Wallstreet
    //{
    //    Stock[] _stocks = new Stock[10];
    //    Fiat[] _fiat = new Fiat[10];

    //    void AddStock(string Name, STOCK sTOCK)
    //    {
    //        _stocks[0] = new Stock(Name, STOCK.APL);
    //    }
    //    void AddFiat(string Name, FIAT Fiat)
    //    {
    //        _fiat[0] = new Fiat(FIAT.GBP, 2);
    //        // Ricerca per YEN 
    //        // Somma delle proprietà _amount;
    //        _fiat[1] = new Fiat(FIAT.YEN, 1000M);
    //        _fiat[2] = new Fiat(FIAT.YEN, 1000000M);
    //    }

    //}
    //class ContoCorrente
    //{
    //    Stock[] _stocks = new Stock[10];

    //    void AddStock(string Name, STOCK sTOCK)
    //    {
    //        _stocks[0] = new Stock(Name, STOCK.APL);//28 Marzo
    //        _stocks[1] = new Stock(Name, STOCK.APL);//29 Marzo
    //        _stocks[2] = new Stock(Name, STOCK.APL);//30 Marzo 
    //        _stocks[3] = new Stock(Name, STOCK.TESLA);//28 Marzo
    //        _stocks[4] = new Stock(Name, STOCK.META);//29 Marzo
    //        _stocks[5] = new Stock(Name, STOCK.BMW);//30 Marzo
    //    }

    //    Stock[] GetStock(STOCK sTOCK)
    //    {
    //        return _stocks.Where(s => s._sTOCK == sTOCK).ToArray();
    //    }

    //    void ShowStocks(STOCK sTOCK) // APPLE
    //    {
    //        Stock[] myarr = GetStock(STOCK.APL);
    //    }
    //}
    //class Fiat
    //{
    //    FIAT _fIAT;
    //    decimal _amount;
    //    public Fiat(FIAT Fiat, decimal amount)
    //    {
    //        _fIAT = Fiat;
    //        _amount = amount;
    //    }
    //}

}

