using System;
using System.Collections.Generic;
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

        
        public Client Client { get { return _Client; } }

        public int BankAccount { get => _bankAccount; set => _bankAccount = value; }

        public Account(string FullName, string CF, CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            int index = checkClient(CF);
            if (index == -1)
            {
                BankAccount = newBankAccount();
                _Client = new Client(FullName, CF, this);
                
            }
            else
            {
                Client clientExist = _commercialBank.ListAccounts[index].Client;
                _Client = clientExist;
                BankAccount = newBankAccount();
                clientExist.addBankAccounts(this);
            }
            listAsset = new List<Asset>();
            
        }

        /*private void addFiatAsset(CommercialBank commercialBank)
        {
            Fiat assetFiat;
            fiat fiatAsset;
            string name;
            decimal value;
            switch (commercialBank.Country)
            {                
                case "Italy": 
                    fiatAsset = fiat.EURO;
                    name = "Euro";
                    value = 1;
                    
                    break;
                case "USA":
                    fiatAsset = fiat.USD;
                    name = "Dollar";
                    value = 2;
                    
                    break;
                case "Swizeland":
                    fiatAsset = fiat.CHF;
                    name = "CHF";
                    value = 3;                   
                    break;  
                    
            }
             
            

        }*/
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

        public void addFiatAsset(fiat fiat, string name, int value)
        {
            Fiat fiatAsset = new Fiat(fiat, name, value);
            listAsset.Add(fiatAsset);           
        }
        public void addCryptoAsset(CRYPTO crypto, string name, int value)
        {
            Crypto CryptoAsset = new Crypto(crypto, name, value);
            listAsset.Add(CryptoAsset);
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
