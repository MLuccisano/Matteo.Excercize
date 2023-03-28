using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    public abstract class Bank
    {
        string _name;
        string _registeredOffice;
        string _country;

        public string RegisteredOffice { get => _registeredOffice; set => _registeredOffice = value; }
        public string Name { get => _name; set => _name = value; }
        public string Country { get => _country; set => _country = value; }

        public Bank(string Name, string RegisteredOffice, string Country)
        {
            this.Name = Name;
            this.RegisteredOffice = RegisteredOffice;
            this.Country = Country;

        }

        public virtual bool Transfer(Bank Destination)
        {
            return false;
        }
    }
}
