using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciaryDesignPattern
{
    abstract class bank
    {
        string _nameBank;
        string _fullName;

        public string FullName { get => _fullName; set => _fullName = value; }
        public string NameBank { get => _nameBank; set => _nameBank = value; }
        public bank(string nameBank, string fullName)
        {
            _fullName = fullName;
            _nameBank = nameBank;
            
        }
    }
}
