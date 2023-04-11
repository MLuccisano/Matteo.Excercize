using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Assets
{
    public abstract class Asset
    {
        string _name;
        decimal _amount;

        public string Name { get => _name; set => _name = value; }
        public decimal Amount { get => _amount; set => _amount = value; }

        public Asset(string Name, decimal Amount)
        {
            this.Name = Name;
            this.Amount = Amount;
        }
    }
}
