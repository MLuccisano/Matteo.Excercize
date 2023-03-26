using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal class Account
    {
        Customer _customer;
        int _bankAccount;
        public int BankAccount { get => _bankAccount; set => _bankAccount = value; }
        public Account(string Name, string Surname, int BankAccount)
        {
            _customer = new Customer(Name, Surname);
            this.BankAccount = BankAccount;
        }
        public string customer { get { return _customer.Name +" "+ _customer.Surname; } }
    }
    class Customer
    {
        string _name;
        string _surname;

        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }

        public Customer(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;

        }
    }
}
