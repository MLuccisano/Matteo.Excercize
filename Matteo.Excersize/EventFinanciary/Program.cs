using System;
using static EventFinanciary.CentralBank;
namespace EventFinanciary
{
    class Program
    {
        static void Main(string[] args)
        {
            CentralBank bdi = new CentralBank("Banca d'Italia", "Matteo Luccisano");
            commercialBank IntesaSanpaolo = new commercialBank("Intesa Sanpaolo", "Matteo Luccisano");
            Stockmarket FTSEMib = new Stockmarket("FTSE Mib", "Matteo Luccisano");
            CryptoExchange Binance = new CryptoExchange("Binance", "Matteo Luccisano");
            bdi.ChangeCEOHandler += new ChangeCeoEventHandler(IntesaSanpaolo.EventChangeCeo);
            bdi.ChangeCEOHandler += new ChangeCeoEventHandler(FTSEMib.EventChangeCeo);
            bdi.ChangeCEOHandler += new ChangeCeoEventHandler(Binance.EventChangeCeo);
            bdi.ChangeCeo("Giordano Bruno");
        }
    }
}
