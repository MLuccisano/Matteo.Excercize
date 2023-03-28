using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class Account
    {
        CommercialBank _commercialBank;
        Customer _Customer;
        int _bankAccount;
        public int BankAccount { get => _bankAccount; }

        public Customer Customer {get{ return _Customer; } }
        public Account(string FullName, string CF, CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            _Customer = new Customer(FullName, CF, this);
            this._bankAccount = new Random().Next(100,100000);
            //_Customer.addBankAccount(this._bankAccount);
        }

    }
    class Customer
    {
        Account _account;
        string _fullname;
        string _cf;
        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Cf { get => _cf; set => _cf = value; }


        /*public void addBankAccount(int bankAccount)
        {
            int[] arrayAccountCopy = new int[cont + 1];
            Array.Copy(_bankAccount, arrayAccountCopy, _bankAccount.Length);
            _bankAccount = arrayAccountCopy;
            _bankAccount[cont] = bankAccount;

        }*/

        public Customer(string FullName,string CF ,Account account)
        {
            this.Fullname = FullName;
            this.Cf = CF;
            _account = account;

        }


    }


}
