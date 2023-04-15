using Es22._03.Banca.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class CentralBank : Bank
    {
        CommercialBank _commercialBank;
        List<CommercialBank> _commercialBanks;
        public CentralBank(string Name,  string City, string Country) : base(Name, City ,Country)
        {
            _commercialBanks = new List<CommercialBank>();
        }
        public CommercialBank commercialBank { get { return _commercialBank; } set { _commercialBank = value; } }
        public List<CommercialBank> CommercialBanks { get => _commercialBanks; }
        public void AddCommercialBank(CommercialBank commercialBank)
        {
            _commercialBanks.Add(commercialBank);

        }
        /*public void visualizeCommercialBank(CommercialBank[] dataCommercialBank)
        {
            foreach (var commercialBank in dataCommercialBank)
            {
                Console.WriteLine($"Name: {commercialBank.Name}");
                Console.WriteLine($"Registered Office: {commercialBank.RegisteredOffice}");
                Console.WriteLine($"Country: {commercialBank.Country}\n");
            }
        }*/


        public bool flowMoney(Bank bankSender, Bank bankDestination)
        {
            if (bankSender.country == bankDestination.country)
            {
                return true;
            }
            else return WorldBank.checkTransfer((CommercialBank)bankSender, (CommercialBank)bankDestination);
        }


        #region CurrencyConverter
        internal protected decimal exchangeRate(fiat currencySender, fiat currencyDestination)
        {
            decimal exchangeRate = 0M;
            if (currencySender == currencyDestination) exchangeRate = 1;
            else
            {
                switch (currencySender)
                {
                    case fiat.EUR:
                        switch (currencyDestination)
                        {
                            case fiat.RUB:
                                exchangeRate = 90.52M;
                                break;
                            case fiat.USD:
                                exchangeRate = 1.09M;
                                break;
                        }
                        break;
                    case fiat.RUB:
                        switch (currencyDestination)
                        {
                            case fiat.EUR:
                                exchangeRate = 0.01M;
                                break;
                            case fiat.USD:
                                exchangeRate = 0.02M;
                                break;
                        }
                        break;
                    case fiat.USD:
                        switch (currencyDestination)
                        {
                            case fiat.RUB:
                                exchangeRate = 82.27M;
                                break;
                            case fiat.EUR:
                                exchangeRate = 1.90M;
                                break;
                        }
                        break;
                }
            }            
            return exchangeRate;
        }
        #endregion
    }
}
