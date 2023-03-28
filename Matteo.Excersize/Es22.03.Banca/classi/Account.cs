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
        public int BankAccount { get => _bankAccount; }

        public Client Client { get{ return _Client; } }
        public Account(string FullName, string CF, CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            _Client = new Client(FullName, CF, this);
            this._bankAccount = newBankAccount();
        }

        public int newBankAccount()
        {
           int num =  new Random().Next(100, 100000);
            return num;
        }

    }
    class Client
    {
        Account _account;
        string _fullname;
        string _cf;
        List<Account> _clients;
        int codClient;
        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Cf { get => _cf; set => _cf = value; }
        public int CodClient { get => codClient; set => codClient = value; }

        public Client(string FullName,string CF ,Account account)
        {
            this.Fullname = FullName;
            this.Cf = CF;
            _account = account;
            this.codClient = CodClient;
        }


        /*public int addBankAccounts(int codClient)
        {
            var index = _clients.FindIndex(data => data.CodClient.Equals(codClient));
            return index;            
        }*/
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
    public class Fiat : Asset
    { 
            
    }


}
