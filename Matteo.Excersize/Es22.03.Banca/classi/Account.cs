using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    class Account
    {
        CommercialBank _commercialBank;
        Client _Client;
        int _bankAccount;
       
        
        public Client Client { get { return _Client; } }

        public int BankAccount { get => _bankAccount; set => _bankAccount = value; }

        public Account(string FullName, string CF, CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            int index = checkClient(CF);
            if (index == -1)
            {
                _Client = new Client(FullName, CF, this);
                this.BankAccount = newBankAccount();
            }
            else
            {
                Client clientExist = _commercialBank.ListAccounts[index].Client;
                _Client = clientExist;
                BankAccount = newBankAccount();
                clientExist.addBankAccounts(this);
            }
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

    }
    
    class Client
    {
        string _fullname;
        string _cf;
        List<Account> _accounts;
        int codClient;
        
        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Cf { get => _cf; set => _cf = value; }
        public int CodClient { get => codClient; set => codClient = value; }
        internal List<Account> Accounts { get => _accounts; set => _accounts = value; }

        public Client(string FullName, string CF, Account account)
        {
            this.Fullname = FullName;
            this.Cf = CF;
            //_account = account;
            this.codClient = CodClient;
            Accounts = new List<Account>();
            addBankAccounts(account);
        }

        public void addBankAccounts(Account account)
        {
            Accounts.Add(account);
            
        }
    }

    internal abstract class Asset
    {
        Account _account;
        public abstract decimal currency { get; }
        public Asset(Account Account)
        {
            _account = Account;
        }
    }


}
