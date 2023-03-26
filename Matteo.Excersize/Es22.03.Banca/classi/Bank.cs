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

        public string RegisteredOffice { get => _registeredOffice; set => _registeredOffice = value; }
        public string Name { get => _name; set => _name = value; }

        public Bank(string Name, string RegisteredOffice)
        {
            this.Name = Name;
            this.RegisteredOffice = RegisteredOffice;
        }
    }
}
