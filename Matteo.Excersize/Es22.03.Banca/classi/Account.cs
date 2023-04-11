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

        //fiat moneta;

        public Client Client {get => _Client; } 
        public int BankAccount { get => _bankAccount; }

        public List<Asset> ListAsset { get => listAsset; }

        public Account(string FullName, string CF, string DateOfBirth,CommercialBank CommercialBank, string Culture)
        {
            _commercialBank = CommercialBank;
            CultureInfo culture = new CultureInfo(Culture);
            string dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            DateTime output;
            //moneta = (fiat)_commercialBank.Moneta;


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
                    addAsset(_commercialBank.Moneta);
                }
                else Console.WriteLine("Sei minorenne. No conto corrente");


            }
            else
            {
                Console.WriteLine("......");
            }            
        }

        private void addAsset(fiat fiat)
        {
            Fiat fiatAsset = new Fiat(fiat, fiat.ToString(), 0);
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
            Asset asset = listAsset.Find(asset => asset.Name.Equals(_commercialBank.Moneta.ToString()));
            Fiat fiatAsset = (Fiat)asset;
            fiatAsset.Deposit(amount);
                     
        }

    }
    
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


}
