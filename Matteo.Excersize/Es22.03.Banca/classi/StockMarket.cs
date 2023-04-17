using Es22._03.Banca.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    public enum STOCKS
    {
        TSLA,
        GAZP,
        HND,
        BMW1,
        PETR4,
        GNR
    }

    class StockMarket : FinancialIntermediary
    {
        List<STOCKS> _listStocks;
        Stock _stock;
        string _country;
        string _UTC;
        
      public List<STOCKS> ListStocks { get => _listStocks; }
        public StockMarket(string name, string country, string city, string UTC) : base(name, country, city)
        {
            _country = country;
            _UTC = UTC;
            _listStocks = new List<STOCKS>();
        }

        protected override Asset BuyStocks(FinancialIntermediary financialIntermediary, STOCKS stocks, decimal Amount)
        {
            if (CheckOpenStockMarket(_UTC) == false) Console.WriteLine($"The Stockmarket of {financialIntermediary.name} from {financialIntermediary.city} is close");
            else _stock = new Stock(stocks, stocks.ToString(), Amount);
           return _stock;
        }     

        internal void visualizeStockAcquired(Account account)
        {
            foreach (Asset stock in account.ListAsset)
            {
                if (stock is Stock) Console.WriteLine(stock.Name);
                else continue;
            }
        }

        protected override void SellStocks(FinancialIntermediary financialIntermediary, Asset stock)
        {
            if (CheckOpenStockMarket(_UTC) == false) Console.WriteLine($"The Stockmarket of {financialIntermediary.name} from {financialIntermediary.city} is close");
            else
            {
                try
                {
                    Stock Stock = (Stock)stock;
                    stock = null;
                }
                catch
                {
                    Console.WriteLine($"{stock.Name} is not a stock");
                }
            }                      
        }

        public void addStocks(STOCKS stock)
        {
            _listStocks.Add(stock);
        }

        internal bool CheckOpenStockMarket(string UTC)
        {            
            DateTime timezoneCity =DateTime.Parse(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, UTC).ToString());
            DateTime OpenMarket = DateTime.Parse("09:00:00");
            DateTime CloseMarket = DateTime.Parse("17:00:00");
            
            int isOpen = timezoneCity.CompareTo(OpenMarket);
            int isClose = timezoneCity.CompareTo(CloseMarket);

            if (isOpen > 0 && isClose < 0) return true;
            else return false;            
        }
        class Stock : Asset
        {
            STOCKS _stocks;

            public Stock(STOCKS stocks, string Name, decimal amount) : base(Name, amount)
            {
                _stocks = stocks;
            }
        }
    }


}
