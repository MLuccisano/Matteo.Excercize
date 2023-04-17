﻿using Es22._03.Banca.Assets;
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
        public CentralBank(string Name, string City, string Country) : base(Name, City, Country)
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
    }
}

