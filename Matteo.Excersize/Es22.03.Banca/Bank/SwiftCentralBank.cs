using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    class SwiftCentralBank : CentralBank, IswiftSystem
    {
        public SwiftCentralBank(string Name, string city, string Country) : base(Name, city, Country)
        {            
        }
        public void applySwift()
        {
        }
    }
}
