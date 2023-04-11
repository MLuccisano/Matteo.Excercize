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


    public class StockMarket : FinancialIntermediary
    {
        Stock _stock;
        string _country;
        string _UTC;
        

        public StockMarket(string name, string country, string city, string UTC) : base(name, country, city)
        {
            _country = country;
            _UTC = UTC;
        }


        protected override Asset BuyStocks(FinancialIntermediary financialIntermediary, STOCKS stocks, string Name, decimal Amount)
        {
            //Console.WriteLine($"the O'clock of {financialIntermediary.name} from {financialIntermediary.city} is {timezoneConverter(financialIntermediary)}");
            if (CheckOpenStockMarket(_UTC) == false)
            {
                Console.WriteLine($"The Stockmarket of {financialIntermediary.name} from {financialIntermediary.city} is close ");
            }
            else
            {
                Console.WriteLine($"The Stockmarket of {financialIntermediary.name} from {financialIntermediary.city} is open ");
            } 
            return _stock;
        }

        class Stock : Asset
        {
            STOCKS _stocks;
            public Stock(STOCKS stocks, string Name,decimal amount) : base(Name, amount)
            {
                _stocks = stocks;
            }
        }

        #region TimezoneConverter
        /*static DateTime timezoneConverter(FinancialIntermediary financialIntermediary)
        {
            DateTime timezone = new DateTime();
            if (financialIntermediary.city == "NY") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Eastern Standard Time");
            else if (financialIntermediary.city == "Milan" || financialIntermediary.city == "Frankfurt") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Central Europe Standard Time");
            else if (financialIntermediary.city == "Moscow") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Moscow Standard Time");
            else if (financialIntermediary.city == "Tokyo") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Tokyo Standard Time");
            else if (financialIntermediary.city == "Sao Paulo") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Brasília Time");
            return timezone;
        }*/

        static bool CheckOpenStockMarket(string UTC)
        {

            //DateTime timezoneCity = timezoneConverter(financialIntermediary);
            DateTime timezoneCity = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, UTC);
            if (timezoneCity.Hour >= 9 && timezoneCity.Minute >= 00 && timezoneCity.Second >= 00 && timezoneCity.Hour <= 17 && timezoneCity.Minute <= 30 && timezoneCity.Second <= 00) return true;
            else return false;
        }
        #endregion
    }

}
