using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    class timeZone
    {
        
        static DateTime timezoneConverter(FinancialIntermediary financialIntermediary)
        {
            DateTime timezone = new DateTime();
            if (financialIntermediary.city == "NY") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Eastern Standard Time");
            if (financialIntermediary.city == "Milan" && financialIntermediary.city == "Frankfurt") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Central European Time");
            if (financialIntermediary.city == "Moscow") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Moscow Standard Time");
            if (financialIntermediary.city == "Tokyo") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Japanese Standard Time");
            if (financialIntermediary.city == "Sao Paulo") timezone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Brasília Time");
            return timezone;
        }

        static bool BuySell(FinancialIntermediary financialIntermediary)
        {

           DateTime timezone = timezoneConverter(financialIntermediary);
           DateTime timezoneUTC = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(timezone, TimeZoneInfo.Local.Id, "Greenwich Mean Time");

            if (timezoneUTC.Hour >= 15 && timezoneUTC.Hour <= 22) return true;
            else return false;
        }
    }
}
