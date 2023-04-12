using Es22._03.Banca.classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    public abstract class Bank : FinancialIntermediary
    {
        string _name;
        string _country;
        public string Country { get => _country; set => _country = value; }
        public string Name { get => _name; set => _name = value; }

        public Bank(string Name, string city, string Country) : base (Name, Country, city)
        {
            _country = Country;
            _name = Name;
        }



        public virtual void Transfer(decimal amount ,Bank Destination, int bankAccountSender, int BankAccountDestination)
        {
            
        }
    }
}
