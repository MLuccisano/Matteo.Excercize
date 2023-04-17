using Es22._03.Banca.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    public abstract class FinancialIntermediary
    {
        public string name;
        public string country;
        public string city;

        public FinancialIntermediary(string Name, string Country, string City) 
        {
            name = Name;
            country = Country.ToLower();
            city = City;
            
        }

        protected virtual Asset BuyStocks(FinancialIntermediary financialIntermediary, STOCKS stocks, decimal amount)
        {
            return financialIntermediary.BuyStocks(financialIntermediary, stocks, amount);
        }

        protected virtual Asset BuyCrypto(FinancialIntermediary financialIntermediary, CRYPTO cryptos)
        {
            return financialIntermediary.BuyCrypto(financialIntermediary, cryptos);
        }

        protected virtual void SellStocks(FinancialIntermediary financialIntermediary, Asset stocks)
        {
            financialIntermediary.SellStocks(financialIntermediary, stocks);
        }

        protected virtual decimal SellCrypto(FinancialIntermediary financialIntermediary, CRYPTO cryptos, decimal amount)
        {
            return financialIntermediary.SellCrypto(financialIntermediary, cryptos, amount);   
        }
    }

}
