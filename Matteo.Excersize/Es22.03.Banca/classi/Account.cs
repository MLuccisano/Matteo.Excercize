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
        public Account(string Name, string Surname,CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            _Customer = new Customer(Name, Surname, this);
            this._bankAccount = new Random().Next(100,100000);
            //_Customer.addBankAccount(this._bankAccount);
        }
    }
    class Customer
    {
        Account _account;
        int[] _bankAccount;
        string _name;
        string _surname;
        int cont;
        
        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }

        /*public void addBankAccount(int bankAccount)
        {
            int[] arrayAccountCopy = new int[cont + 1];
            Array.Copy(_bankAccount, arrayAccountCopy, _bankAccount.Length);
            _bankAccount = arrayAccountCopy;
            _bankAccount[cont] = bankAccount;

        }*/

        public Customer(string Name, string Surname, Account account)
        {
            this.Name = Name;
            this.Surname = Surname;
            _account = account;

        }
    }
}
