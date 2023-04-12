using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es22._03.Banca.Assets;

namespace Es22._03.Banca
{
    class Account
    {
        CommercialBank _commercialBank;
        Client _Client;
        int _bankAccount;
        List<Asset> listAsset;

        #region properties
        public Client Client {get => _Client; } 
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
                        Client clientExist = _commercialBank.ListAccounts[index].Client;
                        _Client = clientExist;
                        _bankAccount = newBankAccount();
                        clientExist.addBankAccounts(this);
                    }
                    listAsset = new List<Asset>();
                    addAsset(_commercialBank.Currency);
                }
                else Console.WriteLine("You are not adult! you cannot open any bankAccounts");


            }
            else
            {
                Console.WriteLine("The date format is wrong");
            }            
        }
        #endregion

        #region Method for Account: AddAsset, newBankAccount, CheckClient, Deposit, withdraw
        private void addAsset(fiat fiat)
        {
            Fiat fiatAsset = new Fiat(fiat, fiat.ToString(), 0M);
            listAsset.Add(fiatAsset);
        }

        private int newBankAccount()
        {
            int num = new Random().Next(100, 100000);
            return num;
        }

        private int checkClient(string CF)
        {
            var result = _commercialBank.ListAccounts.FindIndex(data => data.Client.Cf.Equals(CF));
            return result;
        }

        internal void Deposit(decimal amount)
        {
            Asset asset = listAsset.Find(asset => asset.Name.Equals(_commercialBank.Currency.ToString()));
            Fiat fiatAsset = (Fiat)asset;
            fiatAsset.Deposit(amount);                   
        }
        internal bool Withdraw(decimal amount, string dateMovimentNow, string dateLastMoviment)
        {
            Asset asset = listAsset.Find(asset => asset.Name.Equals(_commercialBank.Currency.ToString()));
            Fiat fiatAsset = (Fiat)asset;
            return fiatAsset.Withdraw(amount, dateMovimentNow, dateLastMoviment);
        }

        #endregion
    }

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
            this.Cf = CF;
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
