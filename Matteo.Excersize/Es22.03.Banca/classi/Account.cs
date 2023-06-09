﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    class Account
    {
        
        CommercialBank _commercialBank;
        Client _Client;
        int _bankAccount;
        List<Asset> listAsset;

        #region properties
        public string ClientCF { get => _Client.Cf; }
        public string ClientFullname { get => _Client.Fullname; }
        public int BankAccount { get => _bankAccount; }

        public List<Asset> ListAsset { get => listAsset; }
        #endregion

        #region ctor Account
        public Account(string FullName, string CF, string DateOfBirth,CommercialBank CommercialBank, string Culture)
        {
            _commercialBank = CommercialBank;
            CultureInfo culture = new CultureInfo(Culture);
            string dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            DateTime output;
            

            if (DateTime.TryParseExact(DateOfBirth, dateFormat, culture, DateTimeStyles.None, out output))
            {
                if (DateTime.Now.AddYears(-18) > output)
                {
                    int index = checkClient(CF);
                    if (index == -1)
                    {
                        _bankAccount = newBankAccount();
                        _Client = new Client(FullName, CF, this);
                    }
                    else
                    {
                        Client clientExist = _commercialBank.ListAccounts[index]._Client;
                        _Client = clientExist;
                        _bankAccount = newBankAccount();
                        clientExist.addBankAccounts(this);
                    }
                    listAsset = new List<Asset>();
                    addFiatAsset(_commercialBank.Currency);
                }
                else Console.WriteLine("You are not adult! you cannot open any bankAccounts");


            }
            else
            {
                Console.WriteLine("The date format is wrong");
            }            
        }
        #endregion

        internal void visualizeStockAcquire (StockMarket stockMarket)
        {
            stockMarket.visualizeStockAcquired(this);
        }

        #region Method for Account: AddAsset, newBankAccount, CheckClient, Deposit, withdraw, payment, searchFiatAsset
        private void addFiatAsset(fiat fiat)
        {
            Fiat fiatAsset = new Fiat(fiat, fiat.ToString(), 0M);
             
            listAsset.Add(fiatAsset);
        }

        internal void addStockAsset(Asset stock)
        {            
            listAsset.Add(stock);           
        }

        internal void addCryptoAsset(Asset crypto)
        {

            listAsset.Add(crypto);
        }

        private void removeStockAsset(Asset stock)
        {
            listAsset.Remove(stock);    
        }
        internal void removeCryptoAsset(Asset crypto)
        {
            listAsset.Remove(crypto);
        }

        private int newBankAccount()
        {
            int num = new Random().Next(100, 100000);
            return num;
        }

        private int checkClient(string CF)
        {
            var result = _commercialBank.ListAccounts.FindIndex(data => data.ClientCF.Equals(CF));
            return result;
        }

        internal bool DepositFiat(decimal amount)
        {
            Fiat fiatAsset = searchFiatAsset();
            return fiatAsset.Deposit(amount);                   
        }
        internal bool WithdrawFiat(decimal amount, string dateMovimentNow)
        {
            Fiat fiatAsset = searchFiatAsset();
            return fiatAsset.Withdraw(amount);
        }
        internal bool payment(decimal amount)
        {
            Fiat fiatAsset = searchFiatAsset();
            return fiatAsset.payment(amount);
        }

        internal int cryptoAsset(CRYPTO crypto)
        {
            var indexCryptoAsset = listAsset.FindIndex(asset => asset.Name.Equals(crypto.ToString()));
            return indexCryptoAsset;
        }

        private Fiat searchFiatAsset()
        {
            Asset asset = listAsset.Find(asset => asset.Name.Equals(_commercialBank.Currency.ToString()));
            Fiat fiatAsset = (Fiat)asset;
            return fiatAsset;
        }

        internal Asset searchStockAsset(STOCKS stocks)
        {
            var indexStock = ListAsset.Find(asset => asset.Name.Equals(stocks.ToString()));
            removeStockAsset(indexStock);
            return indexStock;
        }
        #endregion

        #region Class Client   
        class Client
        {
            string _fullname;
            string _cf;
            List<Account> _accounts;

            public string Fullname { get => _fullname; set => _fullname = value; }
            public string Cf { get => _cf; set => _cf = value; }

            internal List<Account> Accounts { get => _accounts; set => _accounts = value; }
            public Client(string FullName, string CF, Account account)
            {
                this.Fullname = FullName;
                _cf = CF;
                Accounts = new List<Account>();
                addBankAccounts(account);
            }

            public void addBankAccounts(Account account)
            {
                Accounts.Add(account);
            }
        }
        #endregion

    }






}
