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

        public Bank(string Name, string city, string Country) : base (Name, Country, city)
        {
        }



        public virtual bool Transfer(Bank Destination)
        {
            return false;
        }
    }
}
