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
        public int BankAccount { get => _bankAccount; set => _bankAccount = value; }
        public Customer Customer {get{ return _Customer; } }
        public Account(string Name, string Surname, int BankAccount, CommercialBank CommercialBank)
        {
            _commercialBank = CommercialBank;
            _Customer = new Customer(Name, Surname, this);
            this.BankAccount = BankAccount;
        }
    }
    class Customer
    {
        Account _account;
        string _name;
        string _surname;

        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }

        public Customer(string Name, string Surname, Account account)
        {
            this.Name = Name;
            this.Surname = Surname;
            _account = account;

        }
    }
}
