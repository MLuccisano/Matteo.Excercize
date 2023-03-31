using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Assets
{
    public class StockMarket
    {
        string _name;
        string _registeredOffice;
        Stocks[] stocks;
        Stocks _stocks;

        public StockMarket(string Name, string RegisteredOffice)
        {
            _name = Name;
            _registeredOffice = RegisteredOffice;
            _stocks.getStocks();
        }
    }
    class Stocks : Asset
    {
        STOCKS _stocks;
        decimal _stocksValue;
        string _name;
        decimal StocksQuantity;

        protected Stocks(STOCKS stocks, string Name, decimal StocksValue) : base(Name)
        {
            _stocks = stocks;
            _name = Name;
            _stocksValue = StocksValue;
        }

        internal Stocks getStocks()
        {
            return new Stocks(_stocks, _name, _stocksValue);
        }

        public void Deposit(decimal StocksValue)
        {
            Amount += StocksValue;
        }

        public void Withdraw(decimal StocksValue)
        {

            Amount -= StocksValue;
        }
    }
    public enum STOCKS
    {
        BWM,
        HND,
        GAZP,
        TSLA,
    }


}
