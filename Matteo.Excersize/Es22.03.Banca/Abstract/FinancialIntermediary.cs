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
            country = Country;
            city = City;
        }

        protected virtual Asset BuyStocks(FinancialIntermediary financialIntermediary, STOCKS stocks, string name, decimal amount)
        {
            return financialIntermediary.BuyStocks(financialIntermediary, stocks, name, amount);
        }
    }

}
